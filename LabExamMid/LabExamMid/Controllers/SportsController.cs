using LabExamMid.EF;
using LabExamMid.EF.Tables;
using LabExamMid.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExamMid.Controllers
{
    public class SportsController : Controller
    {
        STESContext db = new STESContext();
        // GET: Sports
        public ActionResult Index()
        {
            var enrollments = db.Enrollments
                                    .Include("Student")
                                    .Include("Sport")
                                    .ToList();

            return View(enrollments);
        }

        [HttpGet]
        public ActionResult Enroll()
        {
            var sports = db.Sports.ToList();
            return View(sports);
        }

        [HttpPost]
        public ActionResult Enroll(int[] Sports)
        {
            var selectedSportIds = Sports ?? new int[0];

            if (selectedSportIds.Length > 2)
            {
                ModelState.AddModelError("", "You can only enroll in a maximum of 2 sports.");
                return View("Enroll", db.Sports.ToList());
            }

            var studentId = 1;

            var existingEnrollments = db.Enrollments
                                                .Where(e => e.StudentId == studentId && selectedSportIds.Contains(e.SportId))
                                                .ToList();

            var sportEnrollmentCounts = db.Enrollments
                                                  .Where(e => selectedSportIds.Contains(e.SportId) && e.Status != EnrollmentStatus.Dropped)
                                                  .GroupBy(e => e.SportId)
                                                  .ToDictionary(g => g.Key, g => g.Count());

            foreach (var sportId in selectedSportIds)
            {
                var existingEnrollment = existingEnrollments.FirstOrDefault(e => e.SportId == sportId);

                if (existingEnrollment != null)
                {
                    if (existingEnrollment.Status == EnrollmentStatus.Dropped)
                    {
                        existingEnrollment.Status = EnrollmentStatus.Applied;
                    }
                }
                else
                {
                    var currentStudentsInSport = sportEnrollmentCounts.ContainsKey(sportId) ? sportEnrollmentCounts[sportId] : 0;
                    if (currentStudentsInSport >= 20)
                    {
                        var sportName = db.Sports.Find(sportId)?.Name ?? "A selected sport";
                        ModelState.AddModelError("", $"{sportName} has reached its maximum enrollment limit of 20 students.");
                    }
                    else
                    {
                        var newEnrollment = new Enrollment
                        {
                            StudentId = studentId,
                            SportId = sportId,
                            Status = EnrollmentStatus.Applied
                        };
                        db.Enrollments.Add(newEnrollment);
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Enroll", db.Sports.ToList());
            }

            try
            {
                db.SaveChanges();
                TempData["SuccessMessage"] = "Your enrollment request has been submitted successfully!";
                return RedirectToAction("EnrollmentConfirmation");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An unexpected error occurred while processing your enrollment. Please try again.");
                return View("Enroll",   db.Sports.ToList());
            }
        }

        public ActionResult EnrollmentConfirmation()
        {
            return View();
        }
    }
}