using Lombiq.UIKit.Widgets.Constants;
using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace Lombiq.UIKit.Widgets.Settings;
public class CarouselWidgetPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver<CarouselWidgetPart>
{
    public override IDisplayResult Edit(ContentTypePartDefinition model, BuildEditorContext context) =>
        Initialize<CarouselWidgetPartSettingsViewModel>("CarouselWidgetPartSettings_Edit", viewModel =>
        {
            var settings = model.GetSettings<CarouselWidgetPartSettings>();

            viewModel.Options = settings.Options;
        }).Location("Content");

    public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition model, UpdateTypePartEditorContext context)
    {
        var viewModel = new CarouselWidgetPartSettingsViewModel();

        await context.Updater.TryUpdateModelAsync(
            viewModel,
            Prefix,
            m => m.Options
            );

        var settings = new CarouselWidgetPartSettings
        {
            Options = viewModel.Options ?? DefaultValues.CarouselWidgetPartOptions,
        };

        context.Builder.WithSettings(settings);

        return await EditAsync(model, context);
    }
}
