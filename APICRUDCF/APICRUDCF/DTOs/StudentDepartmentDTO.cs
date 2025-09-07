using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICRUDCF.DTOs
{
    public class StudentDepartmentDTO : StudentDTO
    {
        public DepartmentDTO Dept { get; set; }
    }
}