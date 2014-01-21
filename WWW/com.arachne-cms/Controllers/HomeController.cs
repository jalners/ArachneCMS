using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWW.ViewModels;

namespace WWW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PageModel model = new PageModel(this.HttpContext);
            return View("Index", model);
        }
    }
}
