using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Portal.Data;
using Student_Portal.Models;
using Student_Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Student_Portal.Areas.ApprovedStudent.Controllers
{
    [Area("ApprovedStudent")]
    [Authorize(Roles = UT.ApprovedStudentRole)]
    public class RegisterCourseController : Controller
    {
        public ApplicationDbContext dbContext;
        public RegisterCourseController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult ViewCourses()
        {
            return RedirectToAction("Index", "ViewCourses");
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Course> allCourses = dbContext.Courses.ToList();

            ApplicationUser user = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
            var registeredCourseIds = dbContext.StudentCourses.Where(o => o.StudentId == userId).Select(p => p.CourseId);

            CourseListViewModel courseView = new CourseListViewModel { Courses = dbContext.Courses.Where(o => !registeredCourseIds.Contains(o.Id)).ToList(), StudentId = userId };

            //course.Courses = new List<Course>();course.Courses.Add(new Course { Id = 1 ,Name="Sub1"}); 
            //course.Courses.Add(new Course { Id = 2 ,Name="Sub2"});
            return View(courseView);
        }

        [HttpPost]
        public IActionResult Index(string courseId)
        {
            if (courseId == null)
            {
                return View();
            }
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int CourseCreditRequirement = dbContext.Courses.Where(course => course.Id == courseId).Select(course => course.CreditRequirements).FirstOrDefault();
            List<string> courseIds = dbContext.StudentCourses.Where(entry => entry.StudentId == id && UT.PassGrades.Contains(entry.Grade)).Select(entry => new string(entry.CourseId)).ToList();

            int CurrentCredits=dbContext.Courses.Where(course=>courseIds.Contains(course.Id)).Select(course=>course.Credits).ToList().Sum();/*.Select(course => course.Credits).Sum();*/
            if (CourseCreditRequirement <= CurrentCredits)
            {
                dbContext.StudentCourses.Add(new StudentCourses { StudentId = id, CourseId = courseId, Grade = UT.Unset });
                dbContext.SaveChanges();
                return RedirectToAction("Index", "ViewCourses");
            }
            return RedirectToAction("Message", "Error", new { message= "Credits Insufficient" });
        }
    }
}
