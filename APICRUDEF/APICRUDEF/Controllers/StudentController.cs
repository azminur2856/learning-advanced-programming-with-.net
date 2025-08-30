using APICRUDEF.DTOs;
using APICRUDEF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUDEF.Controllers
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

        IntroEFEntities db = new IntroEFEntities();

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
                var data = GetMapper().Map<List<StudentDepartmentDTO>>(db.Students.ToList());
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
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var ext = db.Students.Find(id);
                if (ext == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Student Not Found");
                }
                var deletedStudent = GetMapper().Map<StudentDTO>(ext);
                db.Students.Remove(ext);
                if (db.SaveChanges() > 0)
                {
                    var responseContent = new
                    {
                        Message = "Student deleted successfully.",
                        Student = deletedStudent
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, responseContent);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured in Deletion of Student");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
