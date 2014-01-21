using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWW.ViewModels;

namespace WWW.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult Index(string language, string category, string id)
        {
            PageModel model = new PageModel(this.HttpContext);

            string viewName = string.Format(
                "~/content/{0}/{1}.{2}.cshtml",
                category,
                id,
                language
            );

            return View(viewName, model);
        }
    }
}
