using Employees.Data.Repository;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Services.Implementations
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            this._departmentRepository = _departmentRepository;
        }

        public async Task<DepartmentModel> Add(DepartmentModel department)
        {
            var result = await _departmentRepository.AddDepartment(department);
            return result;
        }

        public async Task<DepartmentModel> Delete(int departmentId)
        {
            var result = await _departmentRepository.DeleteDepartment(departmentId);
            return result;
        }

        public async Task<DepartmentModel> Get(int departmentId)
        {
            var result = await _departmentRepository.GetDepartment(departmentId);
            return result;
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            List<DepartmentModel> result = new List<DepartmentModel>();
            var department_list = _departmentRepository.GetDepartments();
            foreach (var d in department_list)
            {

                result.Add(d);
            }

            return result;
        }

        public async Task<DepartmentModel> Update(DepartmentModel department)
        {
            var result = await _departmentRepository.UpdateDepartment(department);
            return result;
        }
    }
}
