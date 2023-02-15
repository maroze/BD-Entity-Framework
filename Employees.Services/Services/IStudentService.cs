using Employees.Data.Entities;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Информация о всех студентах из БД
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StudentModel>> GetAll();

        /// <summary>
        /// Информация о студенте заданным id из БД
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<StudentModel> Get(int studentId);

        /// <summary>
        /// Создание студента в БД
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentModel> Add(StudentModel student);

        /// <summary>
        /// Обнавление инф-ции студента в БД
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentModel> Update(StudentModel student);

        /// <summary>
        /// Удаление студента из БД
        /// </summary>
        /// <param name="studentId"></param>
        Task<StudentModel> Delete(int studentId);
    }
}
