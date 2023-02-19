using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.ViewModels
{
   public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }
    }
}
