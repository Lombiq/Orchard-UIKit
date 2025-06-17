using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.ViewModels;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace Lombiq.UIKit.Widgets.Drivers;

public class RandomWidgetDisplayDriver : ContentPartDisplayDriver<RandomWidget>
{
    private readonly IContentDefinitionManager _contentDefinitionManager;
    private readonly IStringLocalizer<RandomWidgetDisplayDriver> T;

    public RandomWidgetDisplayDriver(
        IContentDefinitionManager contentDefinitionManager,
        IStringLocalizer<RandomWidgetDisplayDriver> localizer)
    {
        _contentDefinitionManager = contentDefinitionManager;
        T = localizer;
    }

    public override IDisplayResult Edit(RandomWidget part, BuildPartEditorContext context) =>
        Initialize<RandomWidgetEditorViewModel>(nameof(RandomWidget) + "_Edit", async viewModel =>
        {
            var typeDefinitions = await _contentDefinitionManager.ListTypeDefinitionsAsync();

            viewModel.AvailableContentTypes = typeDefinitions?.Select(type => type.Name) ?? [];
            viewModel.SelectedContentTypes = part.ContentTypes ?? [];
            viewModel.DisplayType = part.DisplayType;
            viewModel.Count = part.Count > 0 ? part.Count : 1;
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

        part.ContentTypes = viewModel.SelectedContentTypes;
        part.DisplayType = viewModel.DisplayType;
        part.Count = viewModel.Count;

        if (!part.ContentTypes.Any()) context.AddModelError(nameof(viewModel.Count), T["Please select at least 1 content type."]);
        if (part.Count < 1) context.AddModelError(nameof(viewModel.Count), T["The count must be at least 1."]);

        return await EditAsync(part, context);
    }
}
