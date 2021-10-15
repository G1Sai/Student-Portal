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

    [Authorize(Roles = UT.AdminRole)]
    [Area("Admin")]
    public class ApproveStudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public ApproveStudentController(ApplicationDbContext _dbContext,UserManager<ApplicationUser> _userManager)
        {
            dbContext = _dbContext;
            userManager = _userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApproveStudentViewModel approveStudentViewModel)
        {
            ApplicationUser student=userManager.FindByIdAsync(approveStudentViewModel.studentId).Result;
            if(userManager.IsInRoleAsync(student,UT.StudentRole).Result)
            {
                if(approveStudentViewModel.approve)
                {
                    await userManager.RemoveFromRoleAsync(student, UT.StudentRole);
                    await userManager.AddToRoleAsync(student, UT.ApprovedStudentRole);
                }
                else
                {
                    await userManager.DeleteAsync(student);
                }
               
            }
            return RedirectToAction("Index","ApproveStudent");
        }
            public IActionResult Index()
        {
            ApproveStudentViewModel approveStudentViewModel = new ApproveStudentViewModel { unapprovedStudents = userManager.GetUsersInRoleAsync(UT.StudentRole).Result.ToList() };
         
            return View(approveStudentViewModel);
        }
    }
}
