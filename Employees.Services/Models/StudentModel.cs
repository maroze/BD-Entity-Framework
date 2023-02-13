using Employees.Data.Entities;
using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }

        public static implicit operator StudentModel(StudentEntityModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new StudentModel
            {
                ID = model.ID,
                LastName = model.LastName,
                FirstMidName = model.FirstMidName,
                EnrollmentDate = model.EnrollmentDate,
                Enrollments = model.Enrollments
            };
        }

        public static implicit operator StudentEntityModel(StudentModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new StudentEntityModel
            {

                ID = model.ID,
                LastName = model.LastName,
                FirstMidName = model.FirstMidName,
                EnrollmentDate = model.EnrollmentDate,
                Enrollments = model.Enrollments

            };
        }
    }
}
