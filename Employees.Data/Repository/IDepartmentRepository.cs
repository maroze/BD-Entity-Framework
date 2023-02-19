using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Информация об учебных дисциплинах
        /// </summary>
        /// <returns></returns>
        IEnumerable<DepartmentEntityModel> GetDepartments();

        /// <summary>
        ///  Информация об учебной дисциплине по id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<DepartmentEntityModel> GetDepartment(int departmentId);
        
        /// <summary>
        /// Создание учебной дисциплины
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<DepartmentEntityModel> AddDepartment(DepartmentEntityModel department);

        /// <summary>
        /// Обновление учебной дисциплины
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<DepartmentEntityModel> UpdateDepartment(DepartmentEntityModel department);

        /// <summary>
        /// Удаление учебной дисциплины
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<DepartmentEntityModel> DeleteDepartment(int departmentId);
    }
}
