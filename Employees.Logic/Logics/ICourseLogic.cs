using Employees.Common.ViewModels;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics
{
    public interface ICourseLogic
    {
        /// <summary>
        /// Возвращает все модули из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseViewModel> GetAllCourses();

        /// <summary>
        /// Возвращает модуль по id из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseViewModel> GetCourse(int courseId);

        /// <summary>
        /// Создание модуля в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> AddCourse(CourseViewModel course);

        /// <summary>
        /// Обновление модуля в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> UpdateCourse(CourseViewModel course);

        /// <summary>
        /// Удаление модуля из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseModel> DeleteCourse(int courseId);
    }
}
