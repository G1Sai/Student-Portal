using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Portal.Data;
using Student_Portal.Models;
using Student_Portal.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Student_Portal.Areas.ApprovedStudent.Controllers
{
    [Area("ApprovedStudent")]
    [Authorize(Roles = UT.ApprovedStudentRole)]
    [Route("/ApprovedStudent/ViewCourses")]
    public class ViewCoursesController : Controller
    {
        public ApplicationDbContext dbContext;
        public ViewCoursesController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult ViewCourses()
        {
            return Index();
        }

        [HttpGet]
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Course> allCourses = dbContext.Courses.ToList();
            //   ApplicationUser user1 = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
            List<CourseViewModel> courses = dbContext.StudentCourses.Where(student => student.StudentId == student.StudentId).Select(courseView => new CourseViewModel { CourseId = courseView.CourseId, CourseName = dbContext.Courses.Where(course => course.Id == courseView.CourseId).Select(course => new string(course.Name)).FirstOrDefault(), Grade = courseView.Grade }).ToList();
            GradeViewModel gradeViewModel = new GradeViewModel { Id = userId, courses = courses };
            return View(gradeViewModel);
        }

        [HttpPost]
        public IActionResult Remove(GradeViewModel gradeView)
        {
            dbContext.StudentCourses.RemoveRange(dbContext.StudentCourses.Where(entry => entry.CourseId == gradeView.CourseId));
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

