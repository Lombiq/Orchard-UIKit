using System.Collections.Generic;

namespace Lombiq.UIKit.Models;

public class BootstrapSplitButton
{
    public string Type { get; set; }
    public string Text { get; set; }
    public string WrapperClasses { get; set; }
    public string ButtonClasses { get; set; }
    public string ToggleClasses { get; set; }
    public string DropdownClasses { get; set; }
    public IEnumerable<(string Url, string Text)> Options { get; set; }
}
