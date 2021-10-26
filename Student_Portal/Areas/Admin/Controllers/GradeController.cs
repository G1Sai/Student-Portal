using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Portal.Data;
using Student_Portal.Models;
using Student_Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UT.AdminRole)]
    public class GradeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public GradeController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index(string id)
        {
            ApplicationUser student = dbContext.ApplicationUser.Where(o => o.Id == id).FirstOrDefault();
            List<CourseViewModel> courses = dbContext.StudentCourses.Where(student => student.StudentId == id).Select(courseView => new CourseViewModel { CourseId = courseView.CourseId, CourseName = dbContext.Courses.Where(course => course.Id == courseView.CourseId).Select(course => new string(course.Name)).FirstOrDefault(), Grade=courseView.Grade }).ToList();
            GradeViewModel gradeViewModel = new GradeViewModel { Name=student.FullName, IdNumber=student.IdNumber, Id=student.Id, courses=courses};
            return View(gradeViewModel);
        }
        [HttpPost]
        public IActionResult UpdateGrade(GradeViewModel gradeViewModel)
        {
            if(gradeViewModel.Grade=='X')
            {
                gradeViewModel.Grade = ' ';
            }
            var Entry = dbContext.StudentCourses.Where(student => student.StudentId == gradeViewModel.Id && student.CourseId == gradeViewModel.CourseId).FirstOrDefault();
                Entry.Grade=gradeViewModel.Grade;
            dbContext.SaveChanges();
            return RedirectToAction("Index","Grade", new { id = gradeViewModel.Id });

        }
    }
}
