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
        /// Возвращает все курсы из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseViewModel> GetAllCourses();

        /// <summary>
        /// Возвращает курс по id из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        CourseViewModel GetCourse(int courseId);

        /// <summary>
        /// Создание курса в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        CourseModel AddCourse(CourseViewModel course);

        /// <summary>
        /// Обновление курса в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> UpdateCourse(CourseViewModel course);

        /// <summary>
        /// Удаление курса из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
       // CourseModel DeleteCourse(int courseId);
    }
}
