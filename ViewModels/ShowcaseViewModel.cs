using System.ComponentModel.DataAnnotations;

namespace Lombiq.UIKit.ViewModels;

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
    public string TextBox3 { get; set; }

    [Required]
    public string TextBox4 { get; set; }
    public string TextBox5 { get; set; }

    [Required]
    public string TextBox6 { get; set; }
    public string TextBox7 { get; set; }
    public string TextBox8 { get; set; }
    public string TextBox9 { get; set; }
    public string TextBox10 { get; set; }
    public string TextBox11 { get; set; }

    [Required]
    public string TextBox1Disabled { get; set; }
    public string TextBox2Disabled { get; set; }
    public string TextBox3Disabled { get; set; }
    public string TextBox4Disabled { get; set; }
    public string TextBox5Disabled { get; set; }

    [Required]
    public bool CheckboxFalse1 { get; set; }
    public bool CheckboxFalse2 { get; set; }
    public bool CheckboxFalse3 { get; set; }
    public bool CheckboxFalse4 { get; set; }
    public bool CheckboxFalse2Disabled { get; set; }

    [Required]
    public bool CheckboxTrue1 { get; set; } = true;
    public bool CheckboxTrue2 { get; set; } = true;
    public bool CheckboxTrue2Disabled { get; set; } = true;

    [Required]
    public bool Dropdown { get; set; }
    public bool DropdownDisabled { get; set; }
    public Status Status { get; set; }
    public Status StatusDisabled { get; set; }
}
