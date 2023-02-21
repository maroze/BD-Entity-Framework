using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAll();
        Task<DepartmentModel> Get(int departmentId);
        Task<DepartmentModel> Add(DepartmentModel department);
        Task<DepartmentModel> Update(DepartmentModel department);
        Task<DepartmentModel> Delete(int departmentId);
    }
}
