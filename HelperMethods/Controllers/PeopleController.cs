﻿using HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person { FirstName = "Adam", LastName = "Freeman", Role = Role.Admin },
            new Person { FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User },
            new Person { FirstName = "John", LastName = "Smith", Role = Role.User },
            new Person { FirstName = "Anne", LastName = "Jones", Role = Role.User }
        };

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = personData;

            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }

            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });

                return Json(formattedData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView(data);
            }
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        // 리팩터링 전
        //private IEnumerable<Person> GetData(string selectedRole)
        //{
        //    IEnumerable<Person> data = personData;

        //    if (selectedRole != "All")
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        data = personData.Where(p => p.Role == selected);
        //    }

        //    return data;
        //}

        //public JsonResult GetPeopleDataJson(string selectedRole = "All")
        //{
        //    //IEnumerable<Person> data = GetData(selectedRole);
        //    var data = GetData(selectedRole).Select(p => new
        //    {
        //        FirstName = p.FirstName,
        //        LastName = p.LastName,
        //        Role = Enum.GetName(typeof(Role), p.Role)
        //    });

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult GetPeople(string selectedRole = "All")
        //{
        //    return View((object)selectedRole);
        //}


        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    // JSON으로 변경
        //    //IEnumerable<Person> data = personData;

        //    //if (selectedRole != "All")
        //    //{
        //    //    Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //    //    data = personData.Where(p => p.Role == selected);
        //    //}

        //    //return PartialView(data);

        //    return PartialView(GetData(selectedRole));
        //}
    }
}