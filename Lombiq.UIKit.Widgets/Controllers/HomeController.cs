using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lombiq.UIKit.Widgets.Controllers
{
    public sealed class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
