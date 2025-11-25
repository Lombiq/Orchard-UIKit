using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Lombiq.UIKit.Widgets.Models;

public class QueryContentItemsWidget : ContentPart
{
    public TextField QueryName { get; set; } = new();
    public TextField SortColumn { get; set; } = new();
    public TextField Order { get; set; } = new();
    public NumericField Limit { get; set; } = new();
    public TextField DisplayType { get; set; } = new();
    public BooleanField ShuffleResults { get; set; } = new();
}
