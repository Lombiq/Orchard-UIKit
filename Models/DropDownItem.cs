using Microsoft.AspNetCore.Mvc.Localization;

namespace Lombiq.UIKit.Models
{
    public class DropDownItem
    {
        public LocalizedHtmlString Text { get; set; }

        public object DataState { get; set; }

        public string DataClass { get; set; }
    }
}
