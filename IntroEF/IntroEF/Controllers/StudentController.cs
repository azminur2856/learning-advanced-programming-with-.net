using IntroEF.DTOs;
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        IntroEFEntities db = new IntroEFEntities();
        public ActionResult Index()
        {
            var data = db.Students.Include("Department").ToList();
            var mappData = DepartmentController.GetMapper().Map<List<StudentDTO>>(data);
            return View(mappData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var deptList = db.Departments.ToList();
            var mappData = DepartmentController.GetMapper().Map<List<DepartmentDTO>>(deptList);
            return View(mappData);
        }

        [HttpPost]
        public ActionResult Create(StudentDTO stu)
        {
            if (stu.Name != null && stu.Cgpa != 0 && stu.Dob != null && stu.DeptId != 0) {
                var mappedStu = DepartmentController.GetMapper().Map<Student>(stu);
                db.Students.Add(mappedStu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            var mappStu = DepartmentController.GetMapper().Map<StudentDTO>(student);
            var deptList = db.Departments.ToList();
            var mappDept = DepartmentController.GetMapper().Map<List<DepartmentDTO>>(deptList);
            
            var viewModel = new Tuple<StudentDTO, List<DepartmentDTO>>(mappStu, mappDept);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentDTO stu)
        {
            if(stu.Name == null || stu.Cgpa == 0 || stu.Dob == null || stu.DeptId == 0)
            {
                return View(stu);
            }
            var mappStu = DepartmentController.GetMapper().Map<Student>(stu);
            var student = db.Students.Find(mappStu.Id);
                student.Name = mappStu.Name;
                student.Dob = mappStu.Dob;
                student.Cgpa = mappStu.Cgpa;
                student.DeptId = mappStu.DeptId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student stu)
        {
            var student = db.Students.Find(stu.Id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}