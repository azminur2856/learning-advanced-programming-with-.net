using AutoMapper;
using IntroEF.DTOs;
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        IntroEFEntities db = new IntroEFEntities();

        public static Mapper GetMapper() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Department>().ReverseMap();
                cfg.CreateMap<DepartmentStudentDTO, Department>().ReverseMap();
                cfg.CreateMap<StudentDTO, Student>().ReverseMap();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public ActionResult Index()
        {
            var deptList = db.Departments.ToList();
            var mappData = GetMapper().Map<List<DepartmentDTO>>(deptList);
            return View(mappData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentDTO dept)
        {
            if (dept.Name != null)
            {
                var mappedDept = GetMapper().Map<Department>(dept);
                db.Departments.Add(mappedDept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentDTO dept)
        {
            if (dept.Name == null)
            {
                return View(dept);
            }
            var mappDept = GetMapper().Map<Department>(dept);
            var existingDept = db.Departments.Find(mappDept.Id);
            existingDept.Name = dept.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var obj = (from d in db.Departments.Include("Students")
                       where d.Id == id
                       select d).SingleOrDefault();

            var mappedObj = GetMapper().Map<DepartmentStudentDTO>(obj);

            return View(mappedObj);
        }
    }
}