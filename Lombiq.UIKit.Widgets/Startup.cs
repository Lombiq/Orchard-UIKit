using Lombiq.UIKit.Widgets.Handlers;
using Lombiq.UIKit.Widgets.Migrations;
using Lombiq.UIKit.Widgets.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Lombiq.UIKit.Widgets;
public sealed class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddContentPart<SlidePart>().AddHandler<SlidePartHandler>();
        services.AddScoped<IDataMigration, CarouselWidgetMigrations>();
    }
}
