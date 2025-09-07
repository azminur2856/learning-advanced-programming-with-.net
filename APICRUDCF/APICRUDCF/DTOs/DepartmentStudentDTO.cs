using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICRUDCF.DTOs
{
    public class DepartmentStudentDTO
    {
        public List<StudentDTO> Students { get; set; }
        public DepartmentStudentDTO()
        {
            Students = new List<StudentDTO>();
        }
    }
}