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

            routes.MapRoute(
                "MyRoute", 
                "{controller}/{action}/{id}/{*catchall}",
                new {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                //new
                //{
                //    controller = "^H.*",                                        // 정규식 제약조건
                //    action = "Index|About",                                     // 여러개의 값을 지정한 제약조건
                //    httpMethod = new HttpMethodConstraint("GET", "POST"),       // 메서드 제약조건
                //    id = new RangeRouteConstraint(10, 20),                      // 지정된 범위 제약조건
                //    id = new CompoundRouteConstraint(new IRouteConstraint[]
                //    {
                //        new AlphaRouteConstraint(),
                //        new MinLengthRouteConstraint(6)
                //    })
                //},
                new[]
                {
                    "URLsAndRoutes.Controllers"
                }
            );
        }
    }
}
