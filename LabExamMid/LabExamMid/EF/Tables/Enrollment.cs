using LabExamMid.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabExamMid.EF.Tables
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int SportId { get; set; }
        [Required]
        public EnrollmentStatus Status { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("SportId")]
        public virtual Sport Sport { get; set; }
    }
}