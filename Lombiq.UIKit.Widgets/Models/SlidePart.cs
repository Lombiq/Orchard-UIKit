using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace Lombiq.UIKit.Widgets.Models;
public class SlidePart : ContentPart
{
    public TextField Title { get; set; } = new();
    public MediaField Image { get; set; } = new();
}
