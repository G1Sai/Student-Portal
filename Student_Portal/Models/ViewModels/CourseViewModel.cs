using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models.ViewModels
{
    public class CourseViewModel
    {
        public List<Course> Courses { get; set; }
        public string CourseId { get; set; }
    }
}
