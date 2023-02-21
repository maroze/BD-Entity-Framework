using Employees.Common.ViewModels;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics
{
    public interface IDepartmentLogic
    {
        IEnumerable<DepartmentViewModel> GetAllDepartments();
        Task<DepartmentViewModel> GetDepartment(int departmentId);
        Task<DepartmentModel> AddDepartment(DepartmentViewModel department);
        Task<DepartmentModel> UpdateDepartment(DepartmentViewModel department);
        Task<DepartmentModel> DeleteDepartment(int departmentId);
    }
}
