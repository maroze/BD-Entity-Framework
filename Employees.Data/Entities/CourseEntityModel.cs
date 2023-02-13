using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Entities
{
    public class CourseEntityModel
    {
        //Id курса
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        //Название курса
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        //Кредиты
        [Range(0, 5)]
        public int Credits { get; set; }

  //      [Column("departmentID")]
        //ВК кафедры
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        //Оценки
        public ICollection<Enrollment> Enrollments { get; set; }

        //Преподаватели
        public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}
