using Employees.Common.ViewModels;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics
{
    public interface IStudentLogic
    {

        /// <summary>
        /// Возвращает всех студентов из БД
        /// </summary>
        /// <returns></returns>
       IEnumerable<StudentViewModel> GetAllStudents();

        /// <summary>
        /// Возвращает студента по id из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<StudentViewModel> GetStudent(int courseId);

        /// <summary>
        /// Создание студента в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<StudentModel> AddStudent(StudentViewModel student);

        /// <summary>
        /// Обновление студента в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<StudentModel> UpdateStudent(StudentViewModel student);

        /// <summary>
        /// Удаление студента из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<StudentModel> DeleteStudent(int studentId);
    }
}
