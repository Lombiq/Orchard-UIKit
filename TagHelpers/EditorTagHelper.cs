using Lombiq.UIKit.Models;
using Lombiq.UIKit.ViewModels;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lombiq.UIKit.TagHelpers
{
    [HtmlTargetElement("editor", Attributes = nameof(Type) + "," + nameof(For))]
    public class EditorTagHelper : BaseShapeTagHelper
    {
        private const string UIKitEditorBaseName = "UIKit__Editor__";

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

        // Otherwise the taghelper can't bind its value to it.
#pragma warning disable CA2227 // Collection properties should be read only
#pragma warning disable MA0016 // Prefer return collection abstraction instead of implementation
        [HtmlAttributeName(nameof(DropdownData))]
        public List<DropdownItem> DropdownData { get; set; }
#pragma warning restore MA0016 // Prefer return collection abstraction instead of implementation
#pragma warning restore CA2227 // Collection properties should be read only

        [HtmlAttributeName(nameof(HideSelectedFromDropdownList))]
        public bool HideSelectedFromDropdownList { get; set; }

        public EditorTagHelper(IShapeFactory shapeFactory, IDisplayHelper displayHelper)
            : base(shapeFactory, displayHelper) { }

        public override Task ProcessAsync(TagHelperContext tagHelperContext, TagHelperOutput output)
        {
            Type = UIKitEditorBaseName + Type;

            foreach (var item in tagHelperContext.AllAttributes)
            {
                Properties.Add(item.Name, item.Value);
            }

            Properties.Add(nameof(ViewContext), ViewContext);

            return base.ProcessAsync(tagHelperContext, output);
        }
    }
}
