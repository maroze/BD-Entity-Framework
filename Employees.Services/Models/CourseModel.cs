using Employees.Common.ViewModels;
using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Models
{
    public class CourseModel
    {
        public int CourseID { get; set; }

        public string Title { get; set; }
        
        public int Credits { get; set; }
   
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public static implicit operator CourseModel(CourseEntityModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new CourseModel
            {
                CourseID = model.CourseID,
                Title = model.Title,
                Credits = model.Credits,
                DepartmentID = model.DepartmentID,
                Department = model.Department,
                Enrollments = model.Enrollments,
                CourseAssignments = model.CourseAssignments
            };
        }

        public static implicit operator CourseEntityModel(CourseModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new CourseEntityModel
            {

                CourseID = model.CourseID,
                Title = model.Title,
                Credits = model.Credits,
                DepartmentID = model.DepartmentID,
                Department = model.Department,
                Enrollments = model.Enrollments,
                CourseAssignments = model.CourseAssignments

            };
        }

       public static implicit operator CourseModel(CourseViewModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new CourseModel
            {
                CourseID = model.CourseID,
                Title = model.Title,
                Credits = model.Credits,
                DepartmentID = model.DepartmentID,
                Department = model.Department,
                Enrollments = model.Enrollments,
                CourseAssignments = model.CourseAssignments
            };
        }

        public static implicit operator CourseViewModel(CourseModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new CourseViewModel
            {
                CourseID = model.CourseID,
                Title = model.Title,
                Credits = model.Credits,
                DepartmentID = model.DepartmentID,
                Department = model.Department,
                Enrollments = model.Enrollments,
                CourseAssignments = model.CourseAssignments
            };
        }

    }
}
