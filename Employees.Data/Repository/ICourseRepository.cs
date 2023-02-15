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
        /// Информация о всех курсах
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CourseEntityModel>> GetCourses();

        /// <summary>
        /// Информация о курсе заданным id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<CourseEntityModel> GetCourse(int courseId);

        /// <summary>
        /// Создание курса
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseEntityModel> AddCourse(CourseEntityModel course);

        /// <summary>
        /// Обнавление курса
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<CourseEntityModel> UpdateCourse(CourseEntityModel course);

        /// <summary>
        /// Удаление курса
        /// </summary>
        /// <param name="courseId"></param>
        Task<CourseEntityModel> DeleteCourse(int courseId);
    }
}
