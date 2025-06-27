using Lombiq.HelpfulLibraries.OrchardCore.Contents;
using Lombiq.UIKit.Widgets.Constants;
using Lombiq.UIKit.Widgets.Models;
using Lombiq.UIKit.Widgets.Settings;
using OrchardCore.ContentFields.Settings;
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

        await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(CarouselWidgetPart), part => part
            .Attachable()
            .WithSettings(new CarouselWidgetPartSettings())
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.Slide, type => type
            .Securable()
            .WithPart<TitlePart>(part => part.WithPosition("0"))
            .WithPart<SlidePart>(part => part.WithPosition("1")));

        await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.CarouselWidget, type => type
            .Securable()
            .WithPart<CarouselWidgetPart>(part => part.WithSettings(new CarouselWidgetPartSettings()))
            .WithPart<BagPart>(part => part.WithSettings(new BagPartSettings
            {
                ContainedContentTypes = [ContentTypes.Slide],
            }))
            .Stereotype(CommonStereotypes.Widget));

        await _contentDefinitionManager.AlterPartDefinitionAsync<CarouselBagWidget>(builder => builder
            .WithField(part => part.SlideSelector, field => field
                .WithSettings(new TextFieldSettings
                {
                    DefaultValue = ".slickCarousel__bagItem",
                    Hint = "The CSS selector for the slide elements inside the widget.",
                    Required = true,
                })
                .WithDisplayName("Slide Element Selector"))
            .WithField(part => part.AdditionalSettings, field => field
                .WithSettings(new TextFieldSettings
                {
                    DefaultValue = "{}",
                    Hint = "A JSON object containing custom Slick configuration. (For more information, see Slick " +
                           "documentation at https://kenwheeler.github.io/slick/#settings",
                    Required = true,
                })
                .WithDisplayName("Additional Settings JSON"))
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(CarouselBagWidget), type => type
            .WithPart<CarouselBagWidget>()
            .WithPart<BagPart>(part => part.WithSettings(new BagPartSettings
            {
                ContainedStereotypes = [CommonStereotypes.Widget],
            }))
            .Stereotype(CommonStereotypes.Widget));

        return 2;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync<CarouselBagWidget>(builder => builder
            .WithField(part => part.SlideSelector, field => field
                .WithSettings(new TextFieldSettings
                {
                    DefaultValue = ".slickCarousel__bagItem",
                    Hint = "The CSS selector for the slide elements inside the widget.",
                    Required = true,
                })
                .WithDisplayName("Slide Element Selector"))
            .WithField(part => part.AdditionalSettings, field => field
                .WithSettings(new TextFieldSettings
                {
                    DefaultValue = "{}",
                    Hint = "A JSON object containing custom Slick configuration. (For more information, see Slick " +
                           "documentation at https://kenwheeler.github.io/slick/#settings",
                    Required = true,
                })
                .WithDisplayName("Additional Settings JSON"))
        );

        await _contentDefinitionManager.AlterTypeDefinitionAsync(nameof(CarouselBagWidget), type => type
            .WithPart<CarouselBagWidget>()
            .WithPart<BagPart>(part => part.WithSettings(new BagPartSettings
            {
                ContainedStereotypes = [CommonStereotypes.Widget],
            }))
            .Stereotype(CommonStereotypes.Widget));

        return 2;
    }
}
