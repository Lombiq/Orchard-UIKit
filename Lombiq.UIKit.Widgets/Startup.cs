using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace Lombiq.UIKit.Widgets
{
    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }
}
