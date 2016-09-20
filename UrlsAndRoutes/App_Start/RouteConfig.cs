using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            routes.MapMvcAttributeRoutes();

            routes.Add(new Route("SayHello", new CoustomRouteHandler()));

            routes.Add(new LegacyRoute(
                "~/articles/Windows_3.1_Overview.html",
                "~/old/.NET_1.0_Class_Library"));

            //routes.MapRoute("MyRoute", "{controller}/{action}");

            //routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });

            routes.MapRoute(
                "MyRoute",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new[]
                {
                    "UrlsAndRoutes.Controllers"
                }
            );
        }
    }
}
