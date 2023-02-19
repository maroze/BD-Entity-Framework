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
        /// Возвращает все уч модули из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseModel> GetAll();

        /// <summary>
        /// Возвращает уч модуль по id из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseModel> Get(int courseId);

        /// <summary>
        /// Создание уч модуля в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> Add(CourseModel course);

        /// <summary>
        /// Обновление уч модуля в БД
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseModel> Update(CourseModel course);

        /// <summary>
        /// Удаление уч модуля из БД
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseModel> Delete(int courseId);
    }
}
