using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Entities
{
    public class DepartmentEntityModel
    {
        [Key]
        // id дисциплины
        public int DepartmentID { get; set; }

        // название дисциплины
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        [DataType(DataType.Currency)]
        // бюджет
        public decimal Budget { get; set; }

        //дата начала
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        //  id преподавателя
        public int? InstructorID { get; set; }

        public InstructorEntityModel Administrator { get; set; }
        public ICollection<CourseEntityModel> Courses { get; set; }
    }
}
