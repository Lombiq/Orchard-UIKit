using Lombiq.UIKit.Widgets.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.DisplayManagement.Views;

namespace Lombiq.UIKit.Widgets.Drivers;

public class ImageLinkWidgetInfoDisplayDriver : ContentPartDisplayDriver<ImageLinkWidget>
{
    private readonly IHtmlLocalizer<ImageLinkWidgetInfoDisplayDriver> H;

    public ImageLinkWidgetInfoDisplayDriver(IHtmlLocalizer<ImageLinkWidgetInfoDisplayDriver> localizer) =>
        H = localizer;

    public override IDisplayResult Edit(ImageLinkWidget part, BuildPartEditorContext context) =>
        Dynamic("Message", shape =>
            {
                shape.Message = new HtmlString("<br>").Join(
                    H["If you don't specify a media text, the images will be displayed as links pointing to themselves like in a gallery."],
                    H["If you want to point to another URL, use the \"{{some media text}}|{{absolute or local link}}\" format."],
                    H["If you want any image to not be a link, set its media text to \"-\" or \"{{some media text}}|-\"."]);
                shape.Type = NotifyType.Information;
            })
            .PlaceInContent(-1);
}
