using Form_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormValidation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //HttpRequestBase instead of FormCollection

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // FormCollection Object

        //[HttpPost]
        //public ActionResult Create(FormCollection fc)
        //{
        //    ViewBag.Name = fc["Name"];
        //    ViewBag.Username = fc["Username"];
        //    ViewBag.Id = fc["Id"];
        //    ViewBag.Dob = fc["Dob"];
        //    ViewBag.Email = fc["Email"];
        //    return View();
        //}

        // Variable Name Maping

        //[HttpPost]
        //public ActionResult Create(string Name, string Username, string Id, DateTime? Dob, string Email)
        //{
        //    ViewBag.Name = Name;
        //    ViewBag.Username = Username;
        //    ViewBag.Id = Id;
        //    ViewBag.Dob = Dob;
        //    ViewBag.Email = Email;
        //    return View();
        //}

        // Model Binding

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                TempData["student"] = student;
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}