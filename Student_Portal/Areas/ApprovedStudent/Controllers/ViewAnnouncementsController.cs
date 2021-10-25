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
    public class ViewAnnouncementsController : Controller
    {
        public ApplicationDbContext dbContext;
        public ViewAnnouncementsController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            AnnouncementViewModel announcementView = new AnnouncementViewModel{ Announcements = dbContext.Announcements.ToList() };
            return View(announcementView);
        }
        public IActionResult ViewCourses()
        {
            return RedirectToAction("Index", "ViewCourses");
        }

    }
}
