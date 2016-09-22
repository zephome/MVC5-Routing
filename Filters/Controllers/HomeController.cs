using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users = "admin")]
        public string Index()
        {
            return "This is the Index action on the Home Controller";
        }

        [GoogleAuth]
        [Authorize(Users = "bob@google.com")]
        public string List()
        {
            return "This is the List action on the Home Controller";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return string.Format("The id value is: {0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }
    }
}