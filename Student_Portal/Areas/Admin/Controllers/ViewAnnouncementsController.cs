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
        [HttpPost]
        public IActionResult Remove(AnnouncementViewModel announcementView)
        {
            dbContext.Announcements.Remove(dbContext.Announcements.Where(o => o.Id == announcementView.Id).FirstOrDefault());
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
