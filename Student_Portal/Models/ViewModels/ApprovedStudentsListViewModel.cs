using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models.ViewModels
{
    public class ApprovedStudentsListViewModel
    {
        public List<ApplicationUser> ApprovedStudents { get; set; }
        public string StudentId{ get; set; }
    }
}
