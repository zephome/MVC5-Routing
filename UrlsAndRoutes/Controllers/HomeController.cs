using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";

            return View("ActionName");
        }

        public ActionResult CustomVariable(string id = "DefaultId", string catchall = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id; // RouteData.Values["id"];
            ViewBag.CatchAll = catchall;

            return View();
        }

        public RedirectToRouteResult MyActionMethod()
        {
            string myActionUrl = Url.Action("Index", new { id = "MyID" });
            string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });

            return RedirectToAction("Index");
        }
    }
}