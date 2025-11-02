using Lombiq.HelpfulLibraries.OrchardCore.ResourceManagement;
using static Lombiq.UIKit.Constants.ResourceNames;

namespace Lombiq.UIKit;

public class ResourceManagementOptionsConfiguration : ResourceManagementOptionsConfiguratorBase
{
    protected override string Area => FeatureIds.Base;

    protected override void Configure(ResourceManagementContext context)
    {
        context.DefineVendorScript(Slick, ("slick/slick.min.js", "slick/slick.js"), "jQuery");
        context.DefineVendorStyle(Slick, ("slick/slick.min.css", "slick/slick.css"));
        context.DefineVendorStyle(SlickTheme, ("slick/slick-theme.min.css", "slick/slick-theme.css"), Slick);

        context.DefineScript(LombiqDropdownScript, "dropdown-editor.js");
        context.DefineScript(LombiqTextBoxScript, "textbox-editor.js");
        context.DefineScript(LombiqSlickCarousel, "slick-carousel.js", Slick);

        context.DefineStyle(LombiqUiKitEditorStyle, "ui-kit-editor.css");
        context.DefineStyle(LombiqShowcaseStyle, "showcase.css");
    }
}
