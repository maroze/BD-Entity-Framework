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

        public IEnumerable<CourseModel> GetAll()
        {
           
            List<CourseModel> result = new List<CourseModel>();
             var course_list = _courseRepository.GetCourses();
            foreach (var c in course_list)
            {

                result.Add(c);
            }

            return result;
        }

        public async Task<CourseModel> Add(CourseModel course)
        {
            var result = await _courseRepository.AddCourse(course);
            return result;
        }

        public async Task<CourseModel> Delete(int courseId)
        {
           return await _courseRepository.DeleteCourse(courseId);
        }

        public async Task<CourseModel> Update(CourseModel course)
        {
            var result = await _courseRepository.UpdateCourse(course);
            return result;
        }

        public async Task<CourseModel> Get(int courseId)
        {
            var result = await _courseRepository.GetCourse(courseId);
            return result;
        }

    }
}
