using Employees.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Информация о всех студентах
        /// </summary>
        /// <returns></returns>
        IEnumerable<StudentEntityModel> GetStudents();

        /// <summary>
        /// Информация о студенте заданным id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<StudentEntityModel> GetStudent(int studentId);

        /// <summary>
        /// Создание студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentEntityModel> AddStudent(StudentEntityModel student);

        /// <summary>
        /// Обнавление инф-ции студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentEntityModel> UpdateStudent(StudentEntityModel student);

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="studentId"></param>
        Task<StudentEntityModel> DeleteStudent(int studentId);
    }
}
