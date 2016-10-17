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
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        [FutureDate(ErrorMessage = "Please enter a date in the future (Attribute)")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage = "You must accept the terms (Attribute)")]
        public bool TermAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }

            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter a date in the future"));
            }

            if (errors.Count == 0 && ClientName == "Joe" && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("You must accept the terms"));
            }

            if (!TermAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms"));
            }

            return errors;
        }
    }
}