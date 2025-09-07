using LabExamMid.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LabExamMid.EF
{
    public class STESContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
    }
}