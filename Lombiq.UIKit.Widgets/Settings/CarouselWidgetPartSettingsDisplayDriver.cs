using GraphQL;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using System.Reflection;

namespace Lombiq.UIKit.Widgets.Settings;
public class CarouselWidgetPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver<CarouselWidgetPart>
{
    public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, BuildEditorContext context) =>
        Initialize<CarouselWidgetPartSettingsViewModel>("CarouselWidgetPartSettings_Edit", model =>
        {
            var settings = contentTypePartDefinition.GetSettings<CarouselWidgetPartSettings>();

            foreach (var property in model.GetType().GetProperties())
            {
                var setting = settings.GetType()?.GetProperty(property.Name)?.GetValue(settings);
                if (setting != null)
                {
                    property.SetValue(model, setting);
                }
            }
        }).Location("Content");

    public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
    {
        var model = new CarouselWidgetPartSettingsViewModel();

        await context.Updater.TryUpdateModelAsync(
            model,
            Prefix
            );

        var settings = new CarouselWidgetPartSettings();

        foreach (var property in settings.GetType().GetProperties())
        {
            var modelProperty = model.GetType()?.GetProperty(property.Name)?.GetValue(model);
            if (modelProperty != null)
            {
                property.SetValue(settings, modelProperty);
            }
        }

        context.Builder.WithSettings(settings);

        return await EditAsync(contentTypePartDefinition, context);
    }

}
