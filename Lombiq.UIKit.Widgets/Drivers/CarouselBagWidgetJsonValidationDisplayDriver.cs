using Lombiq.HelpfulLibraries.Common.Utilities;
using Lombiq.UIKit.Widgets.Models;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace Lombiq.UIKit.Widgets.Drivers;

public class CarouselBagWidgetJsonValidationDisplayDriver : ContentFieldDisplayDriver<TextField>
{
    private readonly IStringLocalizer T;

    public CarouselBagWidgetJsonValidationDisplayDriver(IStringLocalizer<CarouselBagWidgetJsonValidationDisplayDriver> localizer) =>
        T = localizer;

    public override Task<IDisplayResult> UpdateAsync(TextField field, UpdateFieldEditorContext context) =>
        context.PartFieldDefinition.PartDefinition.Name == nameof(CarouselBagWidget) &&
        context.PartFieldDefinition.Name == nameof(CarouselBagWidget.AdditionalSettings)
            ? UpdateInnerAsync(field, context)
            : EditAsync(field, context);

    private async Task<IDisplayResult> UpdateInnerAsync(TextField field, UpdateFieldEditorContext context)
    {
        var viewModel = await context.CreateModelMaybeAsync<EditTextFieldViewModel>(Prefix, () => Task.FromResult(true));
        if (viewModel?.Text is not { Length: > 0 } additionalSettingsJson) return await EditAsync(field, context);

        if (!JsonHelpers.TryParse(additionalSettingsJson, out _))
        {
            context.AddModelError(nameof(field.Text), T["The provided JSON is not valid."]);
        }

        return await EditAsync(field, context);
    }
}
