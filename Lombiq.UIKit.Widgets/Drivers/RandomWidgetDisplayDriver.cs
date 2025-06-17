using Lombiq.HelpfulLibraries.Common.Utilities;
using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Records;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using YesSql;
using YesSql.Services;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Lombiq.UIKit.Widgets.Drivers;

public class RandomWidgetDisplayDriver : ContentPartDisplayDriver<RandomWidget>
{
    private readonly IConfiguration _configuration;
    private readonly IContentDefinitionManager _contentDefinitionManager;
    private readonly IContentItemDisplayManager _contentItemDisplayManager;
    private readonly ISession _session;
    private readonly IStringLocalizer<RandomWidgetDisplayDriver> T;

    public RandomWidgetDisplayDriver(
        IConfiguration configuration,
        IContentDefinitionManager contentDefinitionManager,
        IContentItemDisplayManager contentItemDisplayManager,
        ISession session,
        IStringLocalizer<RandomWidgetDisplayDriver> localizer)
    {
        _configuration = configuration;
        _contentDefinitionManager = contentDefinitionManager;
        _contentItemDisplayManager = contentItemDisplayManager;
        _session = session;
        T = localizer;
    }

    public override IDisplayResult? Display(RandomWidget part, BuildPartDisplayContext context) =>
        part.Count == 0 ? null : Initialize<RandomWidgetDisplayViewModel>(nameof(RandomWidget), async viewModel =>
        {
            // This randomization doesn't need to be cryptographically secure, so we can use this System.Random wrapper.
            // We use an arbitrary constant seed in case this is a UI test, to avoid repeatability issues.
            var randomizer = _configuration.IsUITesting() ? new NonSecurityRandomizer(seed: 839_819_175) : new();

            var typeNames = part.ContentTypes?.AsList() ?? [];
            var query = _session.Query<ContentItem, ContentItemIndex>(index =>
                index.Latest &&
                index.Published &&
                index.ContentType.IsIn(typeNames));

            // Take either some consecutive items from a random point or take the whole set.
            IEnumerable<ContentItem> contentItems;
            if (part.Count > 0)
            {
                var randomIndex = randomizer.GetFromRange(await query.CountAsync());
                contentItems = await query.Skip(randomIndex - part.Count + 1).Take(part.Count).ListAsync();
            }
            else
            {
                contentItems = await query.ListAsync();
            }

            // Then shuffle all items.
            contentItems = contentItems
                .Select(item => (Item: item, OrderBy: randomizer.Get()))
                .OrderBy(pair => pair.OrderBy)
                .ThenBy(pair => pair.Item.Id)
                .Select(pair => pair.Item);

            viewModel.Shapes = await contentItems.AwaitEachAsync(item =>
                _contentItemDisplayManager.BuildDisplayAsync(
                    item,
                    context.Updater,
                    part.DisplayType ?? string.Empty,
                    part.GroupId ?? string.Empty));
        })
        .PlaceInContent();

    public override IDisplayResult Edit(RandomWidget part, BuildPartEditorContext context) =>
        Initialize<RandomWidgetEditorViewModel>(nameof(RandomWidget) + "_Edit", async viewModel =>
        {
            var typeDefinitions = await _contentDefinitionManager.ListTypeDefinitionsAsync();

            viewModel.AvailableContentTypes = typeDefinitions?.Select(type => type.Name) ?? [];
            viewModel.SelectedContentTypes = part.ContentTypes ?? [];
            viewModel.DisplayType = part.DisplayType;
            viewModel.GroupId = part.GroupId;
            viewModel.Count = part.Count == 0 ? 1 : part.Count;
        });

    public override async Task<IDisplayResult> UpdateAsync(RandomWidget part, UpdatePartEditorContext context)
    {
        var viewModel = await context.CreateModelMaybeAsync<RandomWidgetEditorViewModel>(Prefix, () => Task.FromResult(true));
        if (viewModel == null) return await EditAsync(part, context);

        viewModel.SelectedContentTypes =
            context.Updater.ModelState.TryGetValue(
                $"{Prefix}.{nameof(RandomWidgetEditorViewModel.SelectedContentTypes)}",
                out var selected)
                ? (selected.AttemptedValue?.SplitByCommas() ?? [])
                : [];

        if (viewModel.Count < 0) viewModel.Count = -1;

        part.ContentTypes = viewModel.SelectedContentTypes;
        part.DisplayType = viewModel.DisplayType;
        part.GroupId = viewModel.GroupId;
        part.Count = viewModel.Count;

        if (!part.ContentTypes.Any())
        {
            context.AddModelError(nameof(viewModel.Count), T["Please select at least 1 content type."]);
        }

        return await EditAsync(part, context);
    }
}
