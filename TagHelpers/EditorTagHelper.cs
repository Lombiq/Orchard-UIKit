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
    [HtmlTargetElement("editor", Attributes = nameof(Type) + "," + "model-for")]
    [HtmlTargetElement("editor", Attributes = PropertyPrefix + "*")]
    public class EditorTagHelper : BaseShapeTagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        [HtmlAttributeName("model-for")]
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

        public EditorTagHelper(IShapeFactory shapeFactory, IDisplayHelper displayHelper, IHtmlHelper htmlHelper)
            : base(shapeFactory, displayHelper)
            => _htmlHelper = htmlHelper;

        public override Task ProcessAsync(TagHelperContext tagHelperContext, TagHelperOutput output)
        {
            Type = "UiKit__Editor__" + Type;
            Properties.Add(nameof(For), For);
            Properties.Add(nameof(ViewContext), ViewContext);
            Properties.Add(nameof(Disabled), Disabled);
            Properties.Add(nameof(Label), Label?.Value);
            Properties.Add(nameof(Placeholder), Placeholder?.Value);
            Properties.Add(nameof(Hint), Hint?.Value);
            Properties.Add(nameof(BlockClassName), BlockClassName);
            Properties.Add(nameof(BlockId), BlockId);
            Properties.Add(nameof(LabelPosition), LabelPosition);
            Properties.Add(nameof(DropDownContainerId), DropDownContainerId);
            Properties.Add(nameof(ButtonContainerId), ButtonContainerId);
            Properties.Add(nameof(ButtonId), ButtonId);
            Properties.Add(nameof(DropDownData), DropDownData);

            return base.ProcessAsync(tagHelperContext, output);
        }
    }
}
