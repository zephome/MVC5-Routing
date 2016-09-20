using ControllersAndActions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult ProduceOutput()
        {
            if (Server.MachineName == "개발_김형곤")
            {
                //Response.Redirect("/Basic/Index");
                //return new CustomRedirectResult { Url = "/Basic/Index" };
                return new RedirectResult("/Basic/Index");
            }
            else
            {
                //Response.Write("Controller: Derived, Action: ProduceOutput");
                return null;
            }
        }
    }
}