using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Drivers;
using Lombiq.UIKit.Widgets.Migrations;
using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.Settings;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Lombiq.UIKit.Widgets;

public sealed class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ITaxonomyHelper, TaxonomyHelper>();

        services.AddContentPart<SlidePart>();

        services.AddContentPart<CarouselWidgetPart>()
            .WithMigration<CarouselWidgetMigrations>();
        services.AddScoped<IContentTypePartDefinitionDisplayDriver, CarouselWidgetPartSettingsDisplayDriver>();
        services.AddContentPart<CarouselBagWidget>();
        services.AddContentField<TextField>().ForEditor<CarouselBagWidgetJsonValidationDisplayDriver>();

        services.AddContentPart<ButtonWidget>()
            .WithMigration<ButtonWidgetMigrations>();

        services.AddContentPart<SectionWidget>()
            .WithMigration<SectionWidgetMigrations>();

        services.AddContentPart<ImageLinkWidget>()
            .WithMigration<ImageLinkWidgetMigrations>()
            .UseDisplayDriver<ImageLinkWidgetInfoDisplayDriver>();

        services.AddContentPart<CardWidget>()
            .WithMigration<CardWidgetMigrations>();

        services.AddContentPart<RandomWidget>()
            .WithMigration<RandomWidgetMigrations>()
            .UseDisplayDriver<RandomWidgetDisplayDriver>();

        services.AddContentPart<AddMetadataWidget>()
            .WithMigration<AddMetadataWidgetMigrations>();

        services.AddContentPart<QueryContentItemsWidget>()
            .WithMigration<QueryContentItemsWidgetMigrations>();
    }
}
