using APICRUDCF.DTOs;
using APICRUDCF.EF;
using APICRUDCF.EF.Tables;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUDCF.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        UMSContext db = new UMSContext();
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = GetMapper().Map<List<StudentDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("all/dept")]
        public HttpResponseMessage GetAllwithDept()
        {
            try
            {
                var students = db.Students
                         .Include("Dept")
                         .ToList();
                var data = GetMapper().Map<List<StudentDepartmentDTO>>(students);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            try
            {
                var data = GetMapper().Map<Student>(s);
                db.Students.Add(data);
                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured in Creation of Student");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
