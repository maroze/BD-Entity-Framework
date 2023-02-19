using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository
{
    public interface IInstructorRepository
    {
        /// <summary>
        /// Информация о всех преподавателях
        /// </summary>
        /// <returns></returns>
        IEnumerable<InstructorEntityModel> GetInstructors();

        /// <summary>
        /// Информация о преподавателе по id
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns></returns>
        Task<InstructorEntityModel> GetInstructor(int instructorId);

        /// <summary>
        /// Создание преподавателя
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        Task<InstructorEntityModel> AddInstructor(InstructorEntityModel instructor);

        /// <summary>
        /// Обновление преподавателя
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        Task<InstructorEntityModel> UpdateInstructor(InstructorEntityModel instructor);

        /// <summary>
        /// Удаление преподавателя
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns></returns>
        Task<InstructorEntityModel> DeleteInstructor(int instructorId);
    }
}
