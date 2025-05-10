using Lombiq.HelpfulLibraries.OrchardCore.TagHelpers;
using Lombiq.UIKit.Models;
using Lombiq.UIKit.ViewModels;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OrchardCore.DisplayManagement;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Lombiq.UIKit.TagHelpers;

[HtmlTargetElement("editor", Attributes = $"{nameof(Type)},{nameof(For)}")]
public class EditorTagHelper : ShapeTagHelperBase<UiKitEditorViewModel>
{
    private const string UIKitEditorBaseName = "UIKit__Editor__";

    protected override string ShapeType => UIKitEditorBaseName + Type;

    [HtmlAttributeName(nameof(Type))]
    public string Type { get; set; }

    [HtmlAttributeName(nameof(For))]
    public ModelExpression For { get; set; }

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName(nameof(Disabled))]
    public bool Disabled { get; set; }

    [HtmlAttributeName(nameof(Label))]
    public LocalizedHtmlString Label { get; set; }

    [HtmlAttributeName(nameof(LabelPosition))]
    public LabelPosition LabelPosition { get; set; }

    [HtmlAttributeName(nameof(Placeholder))]
    public LocalizedHtmlString Placeholder { get; set; }

    [HtmlAttributeName(nameof(Hint))]
    public LocalizedHtmlString Hint { get; set; }

    [HtmlAttributeName(nameof(HintPosition))]
    public HintPosition HintPosition { get; set; }

    [HtmlAttributeName(nameof(BlockClassName))]
    public string BlockClassName { get; set; }

    [HtmlAttributeName(nameof(BlockId))]
    public string BlockId { get; set; }

    [HtmlAttributeName(nameof(DropdownContainerId))]
    public string DropdownContainerId { get; set; }

    [HtmlAttributeName(nameof(ButtonContainerId))]
    public string ButtonContainerId { get; set; }

    [HtmlAttributeName(nameof(ButtonId))]
    public string ButtonId { get; set; }

    [HtmlAttributeName(nameof(LabelClasses))]
    public string LabelClasses { get; set; }

    [HtmlAttributeName(nameof(IconClasses))]
    public string IconClasses { get; set; }

    [HtmlAttributeName(nameof(InputClasses))]
    public string InputClasses { get; set; }

    [HtmlAttributeName(nameof(MaxLength))]
    public int MaxLength { get; set; }

    [HtmlAttributeName(nameof(DropdownData))]
    [SuppressMessage(
        "Usage",
        "CA2227:Collection properties should be read only",
        Justification = "Otherwise the taghelper can't bind its value to it.")]
    [SuppressMessage("Design", "MA0016:Prefer using collection abstraction instead of implementation", Justification = "Same.")]
    public List<DropdownItem> DropdownData { get; set; }

    [HtmlAttributeName(nameof(HideSelectedFromDropdownList))]
    public bool HideSelectedFromDropdownList { get; set; }

    public EditorTagHelper(IShapeFactory shapeFactory, IDisplayHelper displayHelper)
        : base(displayHelper, shapeFactory) { }

    protected override ValueTask<UiKitEditorViewModel> GetViewModelAsync(TagHelperContext context, TagHelperOutput output) =>
        ValueTask.FromResult(new UiKitEditorViewModel
        {
            BlockId = BlockId,
            BlockClassName = BlockClassName,
            ButtonContainerId = ButtonContainerId,
            ButtonId = ButtonId,
            Disabled = Disabled,
            DropdownContainerId = DropdownContainerId,
            For = For,
            HideSelectedFromDropdownList = HideSelectedFromDropdownList,
            Hint = Hint,
            HintPosition = HintPosition,
            IconClasses = IconClasses,
            InputClasses = InputClasses,
            Label = Label,
            LabelPosition = LabelPosition,
            LabelClasses = LabelClasses,
            MaxLength = MaxLength,
            Placeholder = Placeholder,
            ViewContext = ViewContext,
            DropdownData = DropdownData,
        });
}
