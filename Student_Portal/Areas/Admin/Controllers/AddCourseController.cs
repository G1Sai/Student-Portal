using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Portal.Data;
using Student_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Areas.Admin.Controllers
{
    [Authorize(Roles =UT.AdminRole)]
    [Area("Admin")]
    public class AddCourseController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public AddCourseController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void Index(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            Response.Redirect("ViewCourses");
        }
    }
}
