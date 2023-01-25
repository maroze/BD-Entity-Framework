using System;
using System.Collections.Generic;
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
        /// Внешний ключ
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Знак ? после объявления типа Grade указывает, что свойство Grade допускает значение NULL.
        /// </summary>
        public Grade? Grade { get; set; }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
