using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WWW.Controllers
{
    public class ReferenceController : Controller
    {
        public ActionResult Index(string id)
        {
            string path = string.Concat(
                "/content/reference/",
                (id ?? string.Empty).Replace('.', '/'),
                "/index.html"
            );
            string content = System.IO.File.ReadAllText(this.Server.MapPath(path));

            return View("Index", (object)content);
        }
    }
}
