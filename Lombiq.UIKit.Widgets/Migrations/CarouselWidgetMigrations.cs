using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Models;
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
        await _contentDefinitionManager.AlterTypeDefinitionAsync("Slide", type =>
        type
            .Creatable()
            .Listable()
            .Draftable()
            .Securable()
            .Versionable()
            .WithPart(nameof(SlidePart)));

        await _contentDefinitionManager.AlterTypeDefinitionAsync("CarouselWidget", type =>
        type
            .Creatable()
            .Listable()
            .Draftable()
            .Securable()
            .Versionable()
            .WithPart(nameof(BagPart), part => part.WithSettings(new BagPartSettings 
            {
                ContainedContentTypes = ["Slide"],
            })
            ).Stereotype(CommonStereotypes.Widget));

        return 1;
    }
 }
