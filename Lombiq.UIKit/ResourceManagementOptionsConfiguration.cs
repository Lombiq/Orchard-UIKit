using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using static Lombiq.UIKit.Constants.ResourceNames;

namespace Lombiq.UIKit;

public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{
    private const string Module = "~/Lombiq.UIKit/";
    private const string Css = Module + "css/";
    private const string Js = Module + "js/";
    private const string Vendors = Module + "vendors/";

    private static readonly ResourceManifest _manifest = new();

    static ResourceManagementOptionsConfiguration()
    {
        _manifest
            .DefineScript(Slick)
            .SetUrl(Vendors + "slick/slick.min.js")
            .SetDependencies("jQuery");

        _manifest
            .DefineStyle(Slick)
            .SetUrl(Vendors + "slick/slick.css");

        _manifest
            .DefineStyle(SlickTheme)
            .SetUrl(Vendors + "slick/slick-theme.css")
            .SetDependencies(Slick);

        Script(LombiqDropdownScript, "dropdown-editor");
        Script(LombiqTextBoxScript, "textbox-editor");

        Style(LombiqUiKitEditorStyle, "ui-kit-editor");
        Style(LombiqShowcaseStyle, "showcase");
    }

    public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);

    private static void Style(string name, string file) =>
        _manifest
            .DefineStyle(name)
            .SetUrl($"{Css}{file}.css");

    private static void Script(string name, string file) =>
        _manifest
            .DefineScript(name)
            .SetUrl($"{Js}{file}.js");
}
