using Employees.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Data.Entities
{
    [Table("Student")]
    public class StudentEntityModel
    {
        [Key]
        //ID студента
        public int ID { get; set; }

        //Фамилия
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

         //Имя и Отчество
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        //Дата зачисления
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]     
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        //Общие сведения о обучении
        public ICollection<EnrollmentEntityModel> Enrollments { get; set; }
    }
}
