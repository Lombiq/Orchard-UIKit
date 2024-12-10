using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using OrchardCore.Media.Settings;

namespace Lombiq.UIKit.Widgets.Migrations;

public class CarouselWidgetMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public CarouselWidgetMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync<SlidePart>(
            part =>
            {
                part.WithField(part => part.Title, field => field.WithPosition("0"));
                part.WithField(part => part.Image, field => field.WithSettings(new MediaFieldSettings
                {
                    Multiple = false,
                }).WithPosition("1")
                );
            }
            );

        await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(CarouselWidgetPart), part => part
        .Attachable()
        .WithSettings(new CarouselWidgetPartSettings())
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync("Slide", type =>
        type
            .Securable()
            .WithPart(nameof(SlidePart)));

        await _contentDefinitionManager.AlterTypeDefinitionAsync("CarouselWidget", type =>
        type
            .Securable()
            .WithPart(nameof(CarouselWidgetPart), part => part.WithSettings(new CarouselWidgetPartSettings()))
            .WithPart(nameof(BagPart), part => part.WithSettings(new BagPartSettings
            {
                ContainedContentTypes = ["Slide"],
            })
            ).Stereotype(CommonStereotypes.Widget));

        return 1;
    }
}
