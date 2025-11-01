using Lombiq.HelpfulLibraries.Attributes;
using Lombiq.HelpfulLibraries.OrchardCore.ResourceManagement;
using static Lombiq.UIKit.Constants.ResourceNames;

namespace Lombiq.UIKit;

[LibManVersions]
public partial class ResourceManagementOptionsConfiguration : ResourceManagementOptionsConfiguratorBase
{
    private const string Version = LibMan_kenwheeler_slick;

    protected override string Area => FeatureIds.Base;

    protected override void Configure(ResourceManagementContext context)
    {
        context.DefineVendorScript(Slick, "slick/slick.min.js", "jQuery").SetVersion(Version);
        context.DefineVendorStyle(Slick, "slick/slick.css").SetVersion(Version);
        context.DefineVendorStyle(SlickTheme, "slick/slick-theme.css", Slick).SetVersion(Version);

        context.DefineScript(LombiqDropdownScript, "dropdown-editor.js");
        context.DefineScript(LombiqTextBoxScript, "textbox-editor.js");
        context.DefineScript(LombiqSlickCarousel, "slick-carousel.js", Slick);

        context.DefineStyle(LombiqUiKitEditorStyle, "ui-kit-editor.css");
        context.DefineStyle(LombiqShowcaseStyle, "showcase.css");
    }
}
