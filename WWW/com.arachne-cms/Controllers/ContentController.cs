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
                "~/content/{0}/{1}/{2}.cshtml",
                category,
                id,
                language
            );

            return View(viewName, model);
        }

        public ActionResult Image(string language, string category, string id, string image)
        {
            PageModel model = new PageModel(this.HttpContext);

            string path = string.Format(
                "~/content/{0}/{1}/{3}",
                category,
                id,
                language,
                image
            );

            return this.File(path, MimeMapping.GetMimeMapping(path));
        }
    }
}
