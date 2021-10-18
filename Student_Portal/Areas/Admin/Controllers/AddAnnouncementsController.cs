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
    public class AddAnnouncementsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public AddAnnouncementsController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void Index(Announcement announcement)
        {
            dbContext.Announcements.Add(announcement);
            dbContext.SaveChanges();
            Response.Redirect("ViewAnnouncements");
        }
    }
}
