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
    [Authorize(Roles=UT.ApprovedStudentRole)]
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
            CourseViewModel courseView;
            try
            {
                List<Course> allCourses = dbContext.Courses.ToList();
             //   ApplicationUser user1 = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
                ApplicationUser user = dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault();
                if (user.RegisteredCourses == null)
                {
                    throw new Exception();
                }
                courseView = new CourseViewModel { Courses = user.RegisteredCourses };
            }
            catch (Exception e)
            {
                dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault().RegisteredCourses = new List<Course>();
                dbContext.SaveChanges();
                courseView = new CourseViewModel {Courses=dbContext.ApplicationUser.Where(o => o.Id == userId).FirstOrDefault().RegisteredCourses};
            }
                return View(courseView);
        }
    }
}
