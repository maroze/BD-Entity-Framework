using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        /// <summary>
        /// Внешний ключ Course
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// Внешний ключ Student
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Знак ? после объявления типа Grade указывает, что свойство Grade допускает значение NULL.
        /// </summary>
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
