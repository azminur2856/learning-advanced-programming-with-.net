using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICRUDCF.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public float? Cgpa { get; set; }
        public int DeptId { get; set; }
    }
}