using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using WWW.ViewModels;

namespace WWW.Controllers
{
    public class BlogController : Controller
    {
        private static readonly Regex REGEX_POST = new Regex(@"^(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})-(?<id>.*)$");

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

        public ActionResult Post(string language, string id)
        {
            PageModel model = new PageModel(this.HttpContext);
            Match match = REGEX_POST.Match(id);
            if (match.Success)
            {
                string viewName = string.Format(
                    "~/content/blog/{0}/{1}/{2}/{3}.{4}.cshtml",
                    match.Result("${year}"),
                    match.Result("${month}"),
                    match.Result("${day}"),
                    language,
                    match.Result("${id}")
                );

                return View(viewName, model);
            }
            else
            {
                return this.HttpNotFound();
            }
        }

        public ActionResult Image(string language, string id, string image)
        {
            PageModel model = new PageModel(this.HttpContext);
            Match match = REGEX_POST.Match(id);
            if (match.Success)
            {
                string path = string.Format(
                    "~/content/blog/{0}/{1}/{2}/{3}",
                    match.Result("${year}"),
                    match.Result("${month}"),
                    match.Result("${day}"),
                    image
                );

                return this.File(path, MimeMapping.GetMimeMapping(path));
            }
            else
            {
                return this.HttpNotFound();
            }
        }
    }
}
