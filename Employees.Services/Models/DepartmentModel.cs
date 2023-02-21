using Employees.Common.ViewModels;
using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Models
{
    public class DepartmentModel
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        public static implicit operator DepartmentModel(DepartmentEntityModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new DepartmentModel
            {
                DepartmentID = model.DepartmentID,
                Name = model.Name,
                Budget = model.Budget,
                StartDate = model.StartDate,
                InstructorID = model.InstructorID
            };
        }

        public static implicit operator DepartmentEntityModel(DepartmentModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new DepartmentEntityModel
            {
                DepartmentID = model.DepartmentID,
                Name = model.Name,
                Budget = model.Budget,
                StartDate = model.StartDate,
                InstructorID = model.InstructorID
            };
        }

        public static implicit operator DepartmentModel(DepartmentViewModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new DepartmentModel
            {
                DepartmentID = model.DepartmentID,
                Name = model.Name,
                Budget = model.Budget,
                StartDate = model.StartDate,
                InstructorID = model.InstructorID
            };
        }

        public static implicit operator DepartmentViewModel(DepartmentModel model)
        {
            if (model == null)
            {

                return null;

            }
            else return new DepartmentViewModel
            {
                DepartmentID = model.DepartmentID,
                Name = model.Name,
                Budget = model.Budget,
                StartDate = model.StartDate,
                InstructorID = model.InstructorID
            };
        }
    }
}
