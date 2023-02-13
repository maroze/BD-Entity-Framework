using Employees.Data.Repository;
using Employees.Entities;
using Employees.Services.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository _courseRepository)
        {
            this._courseRepository = _courseRepository;
        }

        public IEnumerable<CourseModel> GetAllCourses()
        {
            var course_list = _courseRepository.GetCourses();
            IEnumerable<CourseModel> result = new IEnumerable<CourseModel>();

            foreach (var c in course_list)
            {

                result.Add(c);
            }

            return result;
        }

        public CourseModel AddCourse(CourseModel course)
        {
            var result = _courseRepository.AddCourse(course);
            return result;
        }

        public CourseModel DeleteCourse(int courseId)
        {
            var result = _courseRepository.DeleteCourse(courseId);
            return result;
        }

        public async Task<CourseModel> UpdateCourse(CourseModel course)
        {
            var result = await _courseRepository.UpdateCourse(course);
            return result;
        }

        public CourseModel GetCourse(int courseId)
        {
            object result = _courseRepository.GetCourse(courseId);
            return result;
        }

    }
}
