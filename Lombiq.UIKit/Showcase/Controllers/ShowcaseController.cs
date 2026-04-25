using Lombiq.UIKit.Showcase.Constants;
using Lombiq.UIKit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.Modules;

namespace Lombiq.UIKit.Showcase.Controllers;

[Feature(FeatureIds.Showcase)]
[Admin(Routes.UIKitShowcase)]
public sealed class ShowcaseController : Controller
{
    [HttpGet]
    public IActionResult Showcase() => View(model: new ShowcaseViewModel());
}
