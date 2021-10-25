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
        public IActionResult Index(Course course)
        {
            try
            {
                if(course.Id==null || course.Name ==null)
                {
                    throw new Exception();
                }
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
                return RedirectToAction("Index","ViewCourses");
            }
            catch(Exception e)
            {
                if (e!=null)
                return RedirectToAction("Index","Error");
            }

            return RedirectToAction("Index","Error");
        }
    }
}
