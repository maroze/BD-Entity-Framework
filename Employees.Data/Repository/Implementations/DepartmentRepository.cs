using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class DepartmentRepository : BaseRepository<DepartmentEntityModel>, IDepartmentRepository
    {
        public DepartmentRepository(SchoolContext _departmentContext) : base(_departmentContext)
        {
        }

        public Task<DepartmentEntityModel> AddDepartment(DepartmentEntityModel department)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentEntityModel> DeleteDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentEntityModel> GetDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentEntityModel> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentEntityModel> UpdateDepartment(DepartmentEntityModel department)
        {
            throw new NotImplementedException();
        }
    }
}
