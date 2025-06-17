using Lombiq.HelpfulLibraries.OrchardCore.Contents;

namespace Lombiq.UIKit.Widgets.ViewModels;

public class RandomWidgetDisplayViewModel
{
    public IEnumerable<string> SelectedContentTypes { get; set; } = [];
    public string? DisplayType { get; set; } = CommonContentDisplayTypes.Summary;
    public int Count { get; set; } = 1;
}

public class RandomWidgetEditorViewModel : RandomWidgetDisplayViewModel
{
    public IEnumerable<string> AvailableContentTypes { get; set; } = [];
}
