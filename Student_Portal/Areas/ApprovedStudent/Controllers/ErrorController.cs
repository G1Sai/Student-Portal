using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Areas.ApprovedStudent.Controllers
{
    [Area("ApprovedStudent")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message(string message)
        {
            return View(model:message );
        }
    }
}
