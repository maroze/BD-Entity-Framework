using Employees.Services.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services
{
    public interface ICourseService
    {
        /// <summary>
        /// Возвращает все курсы из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseModel> GetAll();

        /// <summary>
        /// Возвращает курс по id из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseModel> Get(int courseId);

        /// <summary>
        /// Создание курса в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> Add(CourseModel course);

        /// <summary>
        /// Обновление курса в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> Update(CourseModel course);

        /// <summary>
        /// Удаление курса из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseModel> Delete(int courseId);
    }
}
