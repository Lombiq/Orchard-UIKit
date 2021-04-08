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
    [HtmlTargetElement("editor", Attributes = PropertyPrefix + "*")]
    public class EditorTagHelper : BaseShapeTagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

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

        [HtmlAttributeName(nameof(DropDownContainerId))]
        public string DropDownContainerId { get; set; }

        [HtmlAttributeName(nameof(ButtonContainerId))]
        public string ButtonContainerId { get; set; }

        [HtmlAttributeName(nameof(ButtonId))]
        public string ButtonId { get; set; }

        [HtmlAttributeName(nameof(DropDownData))]
        public List<DropDownItem> DropDownData { get; set; }

        [HtmlAttributeName(nameof(HideSelectedFromDropDownList))]
        public bool HideSelectedFromDropDownList { get; set; }

        [HtmlAttributeName(nameof(CheckBoxStyle))]
        public CheckBoxStyle CheckBoxStyle { get; set; }

        public EditorTagHelper(IShapeFactory shapeFactory, IDisplayHelper displayHelper, IHtmlHelper htmlHelper)
            : base(shapeFactory, displayHelper)
            => _htmlHelper = htmlHelper;

        public override Task ProcessAsync(TagHelperContext tagHelperContext, TagHelperOutput output)
        {
            Type = "UiKit__Editor__" + Type;

            foreach (var item in tagHelperContext.AllAttributes)
            {
                Properties.Add(item.Name, item.Value);
            }

            Properties.Add(nameof(ViewContext), ViewContext);

            return base.ProcessAsync(tagHelperContext, output);
        }
    }
}
