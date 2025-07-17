using FirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.MTitle = "Student List";

            Student s1 = new Student()
            {
                Id = 1,
                Name = "AZMINUR RAHMAN",
                Email = "22-46588-1@student.aiub.edu",
                Address = "Dhaka, Bangladesh"
            };

            Student s2 = new Student()
            {
                Id = 2,
                Name = "ASHANUR RAHMAN",
                Email = "ashanur@gmail.com",
                Address = "Dhaka, Bangladesh"
            };

            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);

            return View(students);
        }

        public ActionResult Create()
        {
            ViewBag.MTitle = "Create Student";
            return View();
        }

        public ActionResult CheckRedirect()
        {
            TempData["Message"] = "This is a message from Student Controller Check Redirect";
            //return RedirectToAction("Index", "Home"); // This will redirect to the Index action of the Home controller
            //return RedirectToAction("Index"); // This will redirect to the Index action of the current controller
            return Redirect("http://www.aiub.edu"); // This will redirect to an external URL
        }
    }
}