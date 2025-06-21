using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Flows.ViewModels;

namespace Lombiq.UIKit.Widgets.Models;

public class AddMetadataWidget : ContentPart
{
    public TextField Alternate { get; set; } = new();
    public TextField Classes { get; set; } = new();
    public TextField DisplayType { get; set; } = new();
    public TextField Wrapper { get; set; } = new();

    public void UpdateShape(IShape shape, BagPartViewModel bagPartViewModel)
    {
        if (Alternate.Text?.Trim() is { Length: > 0 } alternate)
        {
            shape.AddAlternate(alternate);
        }

        if (Classes.Text?.Trim() is { Length: > 0 } classes)
        {
            shape.Classes.AddRange(classes.Split().WhereNot(string.IsNullOrEmpty));
        }

        if (Wrapper.Text?.Trim() is { Length: > 0 } wrapper)
        {
            shape.Metadata.Wrappers.Add(wrapper);
        }
    }
}
