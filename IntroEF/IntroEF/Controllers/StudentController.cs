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
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            if (stu.Name != null && stu.Cgpa != 0 && stu.Dob != null) {
                db.Students.Add(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            var student = db.Students.Find(stu.Id);
                student.Name = stu.Name;
                student.Dob = stu.Dob;
                student.Cgpa = stu.Cgpa;
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