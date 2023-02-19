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
        //Id учебного модуля
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        //Название учебного модуля
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        //Кредиты
        [Range(0, 5)]
        public int Credits { get; set; }

  //      [Column("departmentID")]
        //ВК дисциплины
        public int DepartmentID { get; set; }

        public DepartmentEntityModel Department { get; set; }

        //Оценки
        public ICollection<EnrollmentEntityModel> Enrollments { get; set; }

        //Преподаватели
        public ICollection<CourseAssignmentEntityModel> CourseAssignments { get; set; }

    }
}
