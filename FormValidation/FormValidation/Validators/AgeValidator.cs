using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Validators
{
    public class AgeValidator : ValidationAttribute
    {
        private readonly int minAge;

        public AgeValidator(int minAge)
        {
            this.minAge = minAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Birth is required.");

            DateTime dob;
            bool isValidDate = DateTime.TryParse(value.ToString(), out dob);

            if (!isValidDate)
                return new ValidationResult("Invalid Date of Birth format.");

            var age = DateTime.Today.Year - dob.Year;

            if (dob > DateTime.Today.AddYears(-age)) age--;

            if (age < minAge)
                return new ValidationResult($"Age must be at least {minAge} years.");

            return ValidationResult.Success;

        }

    }
}