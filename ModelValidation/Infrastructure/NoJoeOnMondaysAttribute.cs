using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointment on Mondays (Attribute)";
        }

        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;

            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null)
            {
                return true;
            }
            else
            {
                return !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}