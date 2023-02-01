﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Department
    {
       // [Column("departmentID")]
        public int DepartmentID { get; set; }

       // [Column("name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        [DataType(DataType.Currency)]
       // [Column ( "budget")]
        public decimal Budget { get; set; }

        //[Column("startdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

      //  [Column("instructorID")]
        public int? InstructorID { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
