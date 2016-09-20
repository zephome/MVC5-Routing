using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            DateTime date = DateTime.Now;

            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            return View();
        }

        public RedirectToRouteResult Redirect()
        {
            Random random = new Random();

            TempData["Message"] = random.Next(0, 100).ToString();
            TempData["Date"] = DateTime.Now;

            return RedirectToAction("Index", "Example", new { id = "MyID" });
        }

        public HttpStatusCodeResult StatusCode()
        {
            //return new HttpStatusCodeResult(404, "URL can't be serviced");
            //return HttpNotFound();
            return new HttpUnauthorizedResult();
        }
    }
}