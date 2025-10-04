using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Lombiq.UIKit.Widgets.Models;

public class CarouselBagWidget : ContentPart
{
    public TextField SlideSelector { get; set; } = new();
    public TextField AdditionalSettings { get; set; } = new();
    public TextField SlideDisplayType { get; set; } = new();
}
