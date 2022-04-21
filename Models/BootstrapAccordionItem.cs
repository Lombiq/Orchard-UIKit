using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement;

namespace Lombiq.UIKit.Models;

public class BootstrapAccordionItem
{
    public LocalizedHtmlString Title { get; set; }
    public IShape Shape { get; set; }
}
