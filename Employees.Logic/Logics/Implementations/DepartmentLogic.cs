using Employees.Common.ViewModels;
using Employees.Services.Models;
using Employees.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics.Implementations
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentLogic(IDepartmentService _departmentService)
        {
            this._departmentService = _departmentService;
        }

        public async Task<DepartmentModel> AddDepartment(DepartmentViewModel department)
        {
            DepartmentModel model = department;
            return await _departmentService.Add(model);
        }

        public async Task<DepartmentModel> DeleteDepartment(int departmentId)
        {
            DepartmentModel model = await _departmentService.Delete(departmentId);
            return model;
        }

        public IEnumerable<DepartmentViewModel> GetAllDepartments()
        {
            var departments = _departmentService.GetAll();
            return (IEnumerable<DepartmentViewModel>)departments;
        }

        public async Task<DepartmentViewModel> GetDepartment(int departmentId)
        {
            DepartmentModel model = await _departmentService.Get(departmentId);
            return model;
        }

        public async Task<DepartmentModel> UpdateDepartment(DepartmentViewModel department)
        {
            DepartmentModel model = await _departmentService.Update(department);
            return model;
        }
    }
}
