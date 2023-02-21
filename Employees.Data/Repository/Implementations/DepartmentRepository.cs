using Employees.Entities;
using Microsoft.EntityFrameworkCore;
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
            Insert(department);

            return Task.FromResult(department);
        }

        public async Task<DepartmentEntityModel> DeleteDepartment(int departmentId)
        {
            var result = await GetQuery().FirstOrDefaultAsync(d => d.DepartmentID == departmentId);
            if (result != null)
            {
                Delete(result);

                return result;
            }
            return null;
        }

        public async Task<DepartmentEntityModel> GetDepartment(int departmentId)
        {
            var result = await GetQuery().Include(a => a.Administrator).FirstOrDefaultAsync(d => d.DepartmentID ==departmentId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Кафедра не найдена");
            }
        }

        public IEnumerable<DepartmentEntityModel> GetDepartments()
        {
            return GetAll().ToList();
        }

        public async Task<DepartmentEntityModel> UpdateDepartment(DepartmentEntityModel department)
        {
            await UpdateAsync(department);
            return department;
        }
    }
}
