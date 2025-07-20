using FormValidation.Validators;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Form_Submission.Models
{
    public class Student
    {

        [Required]
        [RegularExpression(@"^([A-Z][a-z]*|[A-Z]+)( ([A-Z][a-z]*|[A-Z]+))*$", ErrorMessage = "Name must contain only letters and spaces, and each word must start with a capital letter or be all uppercase.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "Value must not contain any spaces.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Id must be in the format xx-xxxxx-x, where x is a digit.")]
        public string Id { get; set; }

        [Required]
        [AgeValidator(18, ErrorMessage = "You must be at least 18 years old.")]
        public DateTime Dob { get; set; }

        [Required]
        [AIUBEmailValidator("Id")]
        public string Email { get; set; }
    }
}