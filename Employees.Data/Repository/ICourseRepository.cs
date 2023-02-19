using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Информация о всех учебных модулях
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseEntityModel> GetCourses();

        /// <summary>
        /// Информация об учебном модуле заданным id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseEntityModel> GetCourse(int courseId);

        /// <summary>
        /// Создание учебного модуля
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseEntityModel> AddCourse(CourseEntityModel course);

        /// <summary>
        /// Обновление учебного модуля
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseEntityModel> UpdateCourse(CourseEntityModel course);

        /// <summary>
        /// Удаление учебного модуля
        /// </summary>
        /// <param name="courseId"></param>
        Task<CourseEntityModel> DeleteCourse(int courseId);
    }
}
