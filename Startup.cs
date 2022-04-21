using Lombiq.UIKit.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace Lombiq.UIKit;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services) =>
        services.AddTagHelpers<BootstrapSplitButtonTagHelper>();
}
