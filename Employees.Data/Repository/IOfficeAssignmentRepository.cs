using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository
{
    public interface IOfficeAssignmentRepository
    {
        /// <summary>
        /// Создание преподавательского кабинета
        /// </summary>
        /// <param name="oa"></param>
        /// <returns></returns>
        Task<OfficeAssignmentEntityModel> AddOfficeAssignment(OfficeAssignmentEntityModel oa);

        /// <summary>
        /// Обновление преподавательского кабинета
        /// </summary>
        /// <param name="oa"></param>
        /// <returns></returns>
        Task<OfficeAssignmentEntityModel> UpdateOfficeAssignment(OfficeAssignmentEntityModel oa);


        //Task<OfficeAssignmentEntityModel> DeleteOfficeAssignment(int oaId);
    }
}
