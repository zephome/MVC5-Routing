using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError("ClientName", "Please enter your name");
            }

            if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError("Date", "Please enter date in the future");
            }

            if (!appt.TermAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "You must accept the term");
            }

            if (ModelState.IsValid)
            {
                return View("Complete", appt);
            }
            else
            {
                return View();
            }
        }
    }
}