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

namespace Student_Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UT.AdminRole)]
    public class ViewCoursesController : Controller
    {
        public ApplicationDbContext dbContext;
        public ViewCoursesController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            CourseViewModel courseView = new CourseViewModel{ Courses = dbContext.Courses.Where(o => o == o).ToList() };
            return View(courseView);
        }
    }
}
