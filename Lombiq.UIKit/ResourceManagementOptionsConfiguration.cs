using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using static Lombiq.UIKit.Constants.ResourceNames;

namespace Lombiq.UIKit;

public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{
    private const string Module = "~/Lombiq.UIKit/";
    private const string Css = Module + "css/";
    private const string Js = Module + "js/";

    private static readonly ResourceManifest _manifest = new();

    public ResourceManagementOptionsConfiguration()
    {
        _manifest
            .DefineScript(LombiqDropdownScript)
            .SetUrl(Js + "dropdown-editor.js");

        _manifest
            .DefineScript(LombiqTextBoxScript)
            .SetUrl(Js + "textbox-editor.js");

        _manifest
            .DefineStyle(LombiqCheckBoxStyle)
            .SetUrl(Css + "checkbox.min.css", Css + "checkbox.css");

        _manifest
            .DefineStyle(LombiqDropdownStyle)
            .SetUrl(Css + "dropdown.min.css", Css + "dropdown.css");

        _manifest
            .DefineStyle(LombiqShowcaseStyle)
            .SetUrl(Css + "showcaseStyles.min.css", Css + "showcaseStyles.css");

        _manifest
            .DefineStyle(LombiqTextBoxStyle)
            .SetUrl(Css + "textbox.min.css", Css + "textbox.css");
    }

    public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
}
