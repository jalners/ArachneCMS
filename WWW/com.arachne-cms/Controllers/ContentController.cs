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
                "~/content/{0}/{1}/{2}/index.cshtml",
                language,
                category,
                id
            );

            return View(viewName, model);
        }

        public ActionResult Image(string language, string category, string id, string image)
        {
            PageModel model = new PageModel(this.HttpContext);

            string path = string.Format(
                "~/content/{0}/{1}/{2}/{3}",
                language,
                category,
                id,
                image
            );

            return this.File(path, MimeMapping.GetMimeMapping(path));
        }
    }
}
