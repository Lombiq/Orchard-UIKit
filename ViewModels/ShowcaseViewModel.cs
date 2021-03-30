using System.ComponentModel.DataAnnotations;

namespace Lombiq.UIKit.ViewModels
{
    public class ShowcaseViewModel
    {
        [Required]
        public string RequiredStringEmpty { get; set; }

        [Required]
        public string RequiredStringDefault { get; set; } = "Test string";

        public bool CheckboxFalse { get; set; }
        public bool CheckboxTrue { get; set; } = true;
    }
}
