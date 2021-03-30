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
                .DefineScript(LombiqBootstrapDropDown)
                .SetDependencies("jQuery")
                .SetUrl("~/Lombiq.UIKit/lombiq-uikitscripts/jquery-bootstrap-dropdown.js")
                .SetVersion("1.0");
        }
    }
}
