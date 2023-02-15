using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Entities.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<CourseEntityModel> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}
