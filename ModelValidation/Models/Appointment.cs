using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelValidation.Models
{
    [NoJoeOnMondays]
    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        //[FutureDate(ErrorMessage = "Please enter a date in the future (Attribute)")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        //[MustBeTrue(ErrorMessage = "You must accept the terms (Attribute)")]
        public bool TermAccepted { get; set; }
    }
}