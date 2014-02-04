using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WWW
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BlogPost",
                url: "{language}/blog/{id}",
                defaults: new { controller = "Blog", action = "Post", id = UrlParameter.Optional },
                constraints: new { id = @"^\d{4}-\d{2}-\d{2}-.*$" }
            );

            routes.MapRoute(
                name: "BlogPostImage",
                url: "{language}/blog/{id}/{image}",
                defaults: new { controller = "Blog", action = "Image", id = UrlParameter.Optional },
                constraints: new { id = @"^\d{4}-\d{2}-\d{2}-.*$" }
            );

            var contentConstraints = new { category = @"^(about|contact|o-proekte|wiki)$" };
            routes.MapRoute(
                name: "Content",
                url: "{language}/{category}/{id}",
                defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
                constraints: contentConstraints
            );

            routes.MapRoute(
                name: "ContentImage",
                url: "{language}/{category}/{id}/{image}",
                defaults: new { controller = "Content", action = "Image", id = UrlParameter.Optional },
                constraints: contentConstraints
            );

            //routes.MapRoute(name: "ReferenceGet", url: "reference/{*id}", defaults: new { controller = "Reference", action = "Index", id = UrlParameter.Optional });
            //routes.MapRoute(name: "BlogGet", url: "blog/{*id}", defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}