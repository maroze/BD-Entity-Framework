using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Entities
{
    public class CourseAssignmentEntityModel
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public InstructorEntityModel Instructor { get; set; }
        public CourseEntityModel Course { get; set; }
    }
}
