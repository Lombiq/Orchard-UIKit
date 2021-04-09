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
        public string TextBox1 { get; set; }
        public string TextBox2 { get; set; }

        [Required]
        public string TextBox3 { get; set; }
        public string TextBox4 { get; set; }

        [Required]
        public string TextBox5 { get; set; }
        public string TextBox6 { get; set; }

        [Required]
        public bool CheckboxFalse1 { get; set; }
        public bool CheckboxFalse2 { get; set; }

        [Required]
        public bool CheckboxTrue1 { get; set; } = true;
        public bool CheckboxTrue2 { get; set; } = true;

        public bool DropDown { get; set; }
        public Status Status { get; set; }
    }
}
