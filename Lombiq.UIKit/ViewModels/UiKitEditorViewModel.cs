using Lombiq.UIKit.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OrchardCore.DisplayManagement.Views;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lombiq.UIKit.ViewModels;

public class UiKitEditorViewModel : ShapeViewModel
{
    public string BlockId { get; set; }
    public string BlockClassName { get; set; }
    public string ButtonContainerId { get; set; }
    public string ButtonId { get; set; }
    public bool Disabled { get; set; }
    public string DropdownContainerId { get; set; }
    public ModelExpression For { get; set; }
    public bool HideSelectedFromDropdownList { get; set; }
    public LocalizedHtmlString Hint { get; set; }
    public HintPosition HintPosition { get; set; }
    public string IconClasses { get; set; }
    public string InputClasses { get; set; }
    public LocalizedHtmlString Label { get; set; }
    public LabelPosition LabelPosition { get; set; }
    public string LabelClasses { get; set; }
    public int? MaxLength { get; set; }
    public LocalizedHtmlString Placeholder { get; set; }
    public ViewContext ViewContext { get; set; }

    [SuppressMessage(
        "Usage",
        "CA2227:Collection properties should be read only",
        Justification = "Shape properties should not be read-only.")]
    public IList<DropdownItem> DropdownData { get; set; }

    public UiKitEditorViewModel() => Metadata.Type = "EditorDropdown";
}
