using System;
using System.Collections.Generic;

namespace Employees.Common.ViewModels
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public DepartmentViewModel Department { get; set; }

        public ICollection<EnrollmentViewModel> Enrollments { get; set; }

        public ICollection<CourseAssignmentViewModel> CourseAssignments { get; set; }
    }
}
