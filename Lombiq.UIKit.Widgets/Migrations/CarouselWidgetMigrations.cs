using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Constants;
using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using OrchardCore.Media.Settings;
using OrchardCore.Title.Models;

namespace Lombiq.UIKit.Widgets.Migrations;

public class CarouselWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public CarouselWidgetMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync<SlidePart>(part => part
            .WithField(part => part.Image, field => field.WithSettings(new MediaFieldSettings
            {
                Multiple = false,
            })
            .WithPosition("0")
        ));

        await _contentDefinitionManager.AlterPartDefinitionAsync(ContentTypes.CarouselWidgetPart, part => part
            .Attachable()
            .WithSettings(new CarouselWidgetPartSettings())
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.Slide, type => type
            .Securable()
            .WithPart(nameof(TitlePart), part => part
                .WithPosition("0"))
            .WithPart(ContentTypes.SlidePart, part => part
                .WithPosition("1")
            ));

        await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.CarouselWidget, type => type
            .Securable()
            .WithPart(ContentTypes.CarouselWidgetPart, part => part.WithSettings(new CarouselWidgetPartSettings()))
            .WithPart(nameof(BagPart), part => part.WithSettings(new BagPartSettings
            {
                ContainedContentTypes = [ContentTypes.Slide],
            })
            ).Stereotype(CommonStereotypes.Widget));

        return 1;
    }
}
