using System.ComponentModel.DataAnnotations;

namespace Lombiq.UIKit.ViewModels
{
    public enum Status
    {
        Approved,
        Denied,
        Pending,
    }

    public class ShowcaseViewModel
    {
        [Required]
        public string RequiredStringEmpty { get; set; }

        public string NotRequiredStringEmpty { get; set; }

        [Required]
        public string RequiredStringDefault { get; set; } = "Test string";

        [Required]
        public bool CheckboxFalse { get; set; }
        public bool CheckboxTrue { get; set; } = true;
        public Status Status { get; set; }
    }
}
