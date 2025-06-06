using Fluid;
using Fluid.Values;
using Lombiq.HelpfulLibraries.Common.Utilities;
using Lombiq.UIKit.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Liquid;
using OrchardCore.Title.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Handlers;

public class HtmlTitlePartHandler : ContentPartHandler<HtmlTitlePart>
{
    private readonly HashSet<ContentItem> _handledContentItems = [];
    private readonly ILiquidTemplateManager _liquidTemplateManager;

    public HtmlTitlePartHandler(ILiquidTemplateManager liquidTemplateManager) =>
        _liquidTemplateManager = liquidTemplateManager;

    public override Task UpdatedAsync(UpdateContentContext context, HtmlTitlePart part) => SetTitleAsync(part);
    public override Task CreatedAsync(CreateContentContext context, HtmlTitlePart part) => SetTitleAsync(part);

    private async Task SetTitleAsync(HtmlTitlePart part)
    {
        var title = part.Title.Html;
        if (!_handledContentItems.Add(part.ContentItem) || string.IsNullOrWhiteSpace(title)) return;

        if (title.Contains("{{") || title.Contains("{%"))
        {
            var model = new TitlePartViewModel
            {
                Title = title,
                TitlePart = new() { ContentItem = part.ContentItem, Title = title },
                ContentItem = part.ContentItem,
            };

            title = await _liquidTemplateManager.RenderStringAsync(
                title,
                NullEncoder.Default,
                model,
                new Dictionary<string, FluidValue>
                {
                    [nameof(ContentItem)] = new ObjectValue(model.ContentItem),
                });
        }

        part.ContentItem.DisplayText = HtmlHelper
            .ConvertToPlainText(title)
            .Replace("\r", string.Empty).Replace("\n", string.Empty);
        part.Apply();
    }
}
