using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models.ViewModels
{
    public class ApproveStudentViewModel
    {
        public List<ApplicationUser> unapprovedStudents { get; set; }
        public string studentId { get; set; }
        public bool approve { get; set; }
    }
}
