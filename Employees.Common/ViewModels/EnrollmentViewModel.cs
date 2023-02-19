using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.ViewModels
{
    public enum GradeView
    {
        A, B, C, D, F
    }
    public class EnrollmentViewModel
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public GradeView? Grade { get; set; }
    }
}
