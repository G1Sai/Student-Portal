using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models
{
    public class StudentCourses
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string EntryId { get; set; }
        [ForeignKey("ApplicationUser")]
        public virtual string StudentId { get; set; }
        [ForeignKey("Course")]
        public virtual string CourseId { get; set; }
        public char Grade { get; set; } = UT.Unset;
    }
}
