using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models.ViewModels
{
    public class GradeViewModel
    {
        public List<CourseViewModel> courses { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string IdNumber { get; set; }
        public string CourseId { get; set; }
        public char Grade { get; set; }

    }
}
