using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ApprovedStudentListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public ApprovedStudentListController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
        {
            dbContext = _dbContext;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            ApprovedStudentsListViewModel students = new ApprovedStudentsListViewModel { ApprovedStudents = userManager.GetUsersInRoleAsync(UT.ApprovedStudentRole).Result.ToList() };
        
            return View(students);
        }

        [HttpPost]
        public IActionResult Index(ApprovedStudentsListViewModel approvedStudentList)
        {
            return RedirectToAction("Index","Grade",new { id = approvedStudentList.StudentId });
        }
    }
}
