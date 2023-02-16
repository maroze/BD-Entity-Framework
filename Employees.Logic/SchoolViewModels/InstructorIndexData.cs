using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Entities.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<InstructorEntityModel> Instructors { get; set; }
        public IEnumerable<CourseEntityModel> Courses { get; set; }
        public IEnumerable<EnrollmentEntityModel> Enrollments { get; set; }

    }
}
