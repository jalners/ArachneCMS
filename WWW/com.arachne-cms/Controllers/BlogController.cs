using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WWW.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index(string id)
        {
            string path = string.Concat(
                "/content/blog/",
                (id ?? string.Empty).Replace('.', '/'),
                ".html"
            );
            string content = System.IO.File.ReadAllText(this.Server.MapPath(path));

            return View("Index", (object)content);
        }
    }
}
