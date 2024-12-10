using Lombiq.UIKit.Widgets.Models;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Title.Models;
using OrchardCore.Title.ViewModels;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Lombiq.UIKit.Widgets.Settings;
public class CarouselWidgetPartSettingsDisplayDriver : ContentTypePartDefinitionDisplayDriver<CarouselWidgetPart>
{
    public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, BuildEditorContext context) =>
        Initialize<CarouselWidgetPartSettingsViewModel>("CarouselWidgetPartSettings_Edit", model =>
        {
            var settings = contentTypePartDefinition.GetSettings<CarouselWidgetPartSettings>();
            model.Accessibility = settings.Accessibility;
            model.Draggable = settings.Draggable;
            model.Dots = settings.Dots;
            model.DotsClass = settings.DotsClass;
            model.CenterPadding = settings.CenterPadding;
        }).Location("Content");

    public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
    {
        var model = new CarouselWidgetPartSettingsViewModel();

        await context.Updater.TryUpdateModelAsync(
            model,
            Prefix,
            m => m.Accessibility,
            m => m.Dots,
            m => m.DotsClass,
            m => m.CenterPadding,
            m => m.Draggable
            );
        context.Builder.WithSettings(new CarouselWidgetPartSettings
        {
            Accessibility = model.Accessibility,
            Draggable = model.Draggable,
            Dots = model.Dots,
            CenterPadding = model.CenterPadding,
            DotsClass = model.DotsClass,
        }
        );
        return await EditAsync(contentTypePartDefinition, context);
    }

}
