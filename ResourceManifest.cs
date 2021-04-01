using OrchardCore.ResourceManagement;
using static Lombiq.UIKit.Constants.ResourceNames;

namespace Lombiq.UIKit
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript(LombiqDropDownScript)
                .SetDependencies("jQuery")
                .SetUrl("~/Lombiq.UIKit/js/jquery-bootstrap-dropdown.js")
                .SetVersion("1.0");

            manifest
                .DefineStyle(LombiqTextBoxStyle)
                .SetUrl("~/Lombiq.UIKit/css/textBox.min.css", "~/Finitive.Theme/css/textBox.css");
        }
    }
}
