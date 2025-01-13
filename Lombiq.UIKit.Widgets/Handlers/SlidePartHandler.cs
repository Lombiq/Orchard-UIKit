using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Handlers;

namespace Lombiq.UIKit.Widgets.Handlers;

public class SlidePartHandler : ContentPartHandler<SlidePart>
{
    public override Task UpdatedAsync(UpdateContentContext context, SlidePart part) =>
        Task.Run(() => context.ContentItem.DisplayText = part.ContentItem.Content.TitlePart.Text);
}
