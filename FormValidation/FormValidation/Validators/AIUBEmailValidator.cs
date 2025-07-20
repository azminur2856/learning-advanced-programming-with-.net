using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Validators
{
    public class AIUBEmailValidator: ValidationAttribute
    {
        private readonly string Id;

        public AIUBEmailValidator(string Id)
        {
            this.Id = Id;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var idProperty = validationContext.ObjectType.GetProperty(Id);
            if (idProperty == null)
            {
                return new ValidationResult($"Unknown property: {Id}");
            }

            var idValue = idProperty.GetValue(validationContext.ObjectInstance, null) as string;
            var emailValue = value as string;

            if (string.IsNullOrEmpty(emailValue))
                return new ValidationResult("Email is required.");

            if (string.IsNullOrEmpty(idValue))
                return new ValidationResult("Id must be provided before validating email.");

            var expectedEmail = $"{idValue}@student.aiub.edu";

            if (emailValue.ToLower() != expectedEmail.ToLower())
            {
                return new ValidationResult("Email must be in the format 'xx-xxxxx-x@student.aiub.edu' and match the ID.");
            }

            return ValidationResult.Success;
        }
    }
}