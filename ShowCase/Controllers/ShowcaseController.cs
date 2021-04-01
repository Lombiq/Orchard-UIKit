using Lombiq.UIKit.ShowCase.Constants;
using Lombiq.UIKit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Modules;

namespace Lombiq.UIKit.ShowCase.Controllers
{
    [Feature(FeatureIds.ShowCase)]
    public class ShowCaseController : Controller
    {
        [HttpGet(Routes.UIKitShowCase)]
        public ActionResult ShowCase() => View(model: new ShowcaseViewModel());
    }
}