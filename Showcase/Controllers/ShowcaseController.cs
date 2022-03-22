using Lombiq.UIKit.Showcase.Constants;
using Lombiq.UIKit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.Modules;

namespace Lombiq.UIKit.Showcase.Controllers;

[Feature(FeatureIds.Showcase)]
[Admin]
public class ShowcaseController : Controller
{
    [HttpGet(Routes.UIKitShowcase)]
    public ActionResult Showcase() => View(model: new ShowcaseViewModel());
}
