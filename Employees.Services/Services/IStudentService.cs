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
        IEnumerable<StudentModel> GetStudents();

        /// <summary>
        /// Информация о студенте заданным id из БД
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        StudentModel GetStudent(int studentId);

        /// <summary>
        /// Создание студента в БД
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        StudentModel AddStudent(StudentModel student);

        /// <summary>
        /// Обнавление инф-ции студента в БД
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentModel> UpdateStudent(StudentModel student);

        /// <summary>
        /// Удаление студента из БД
        /// </summary>
        /// <param name="studentId"></param>
        StudentModel DeleteStudent(int studentId);
    }
}
