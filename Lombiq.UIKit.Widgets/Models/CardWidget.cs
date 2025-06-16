using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Media.Fields;

namespace Lombiq.UIKit.Widgets.Models;

public class CardWidget : ContentPart
{
    public MediaField Image { get; set; } = new();
    public BooleanField ImageBottom { get; set; } = new();
}
