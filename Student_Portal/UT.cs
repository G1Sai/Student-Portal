using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal
{
    public class UT
    {
        public const string AdminRole = "Admin";
        public const string StudentRole = "Student";
        public const char Distinction = 'A';
        public const char Pass = 'C';
        public const char FailGrade  = 'F';
        public const char Unset = ' ';
        public const char Reset = 'X';
        public static readonly char[] PassGrades =  { 'A','C'};
        public static readonly char[] FailGrades =  { 'F',' '};
        public const string ApprovedStudentRole = "Approved_Student";
    }
}
