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
    [Authorize(Roles=UT.ApprovedStudentRole)]
    public class RegisterCourseController : Controller
    {
        public ApplicationDbContext dbContext;
        public RegisterCourseController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult ViewCourses()
        {
            return RedirectToAction("Index","ViewCourses");
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Course> allCourses = dbContext.Courses.ToList();
            ApplicationUser user = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
            if (dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault().RegisteredCourses == null)
            {
                dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault().RegisteredCourses = new List<Course>();
            }
            var appuser = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
            dbContext.SaveChanges();
            List<Course> registeredCourses = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault().RegisteredCourses.ToList();
            CourseViewModel courseView = new CourseViewModel { Courses = allCourses.Where(o => registeredCourses.All(p => p.Id != o.Id)).ToList() };

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
            if (dbContext.ApplicationUser.Where(o => o.Id == id).FirstOrDefault().RegisteredCourses == null)
            {
                dbContext.ApplicationUser.Where(o => o.Id == id).FirstOrDefault().RegisteredCourses = new List<Course>();
            }
            dbContext.ApplicationUser.Where(o => o.Id == id).FirstOrDefault().RegisteredCourses.Add(dbContext.Courses.Where(o => o.Id == courseId).FirstOrDefault());
            dbContext.SaveChanges();
            return View();
        }
    }
}
