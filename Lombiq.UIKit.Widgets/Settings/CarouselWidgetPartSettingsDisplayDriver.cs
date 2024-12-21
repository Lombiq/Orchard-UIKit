using Lombiq.UIKit.Widgets.Constants;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace Lombiq.UIKit.Widgets.Settings;
public class CarouselWidgetPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver<CarouselWidgetPart>
{
    public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, BuildEditorContext context) =>
        Initialize<CarouselWidgetPartSettingsViewModel>("CarouselWidgetPartSettings_Edit", model =>
        {
            var settings = contentTypePartDefinition.GetSettings<CarouselWidgetPartSettings>();

            model.Options = settings.Options;
        }).Location("Content");

    public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
    {
        var model = new CarouselWidgetPartSettingsViewModel();

        await context.Updater.TryUpdateModelAsync(
            model,
            Prefix,
            m => m.Options
            );

        var settings = new CarouselWidgetPartSettings
        {
            Options = model.Options ?? DefaultValues.CarouselWidgetPartOptions,
        };

        context.Builder.WithSettings(settings);

        return await EditAsync(contentTypePartDefinition, context);
    }

}
