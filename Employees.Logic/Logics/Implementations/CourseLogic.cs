using Employees.Common.ViewModels;
using Employees.Services;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics.Implementations
{
    public class CourseLogic : ICourseLogic
    {
        private readonly ICourseService _courseService;

        public CourseLogic(ICourseService _courseService)
        {
            this._courseService = _courseService;
        }
        public async Task<CourseModel> AddCourse(CourseViewModel course)
        {
            CourseModel model = course;

            return await _courseService.Add(model);
        }

        public async Task<CourseModel> DeleteCourse(int courseId)
        {
            CourseModel model = await _courseService.Delete(courseId);
            return model;
        }

        public IEnumerable<CourseViewModel> GetAllCourses()
        { 
            var courses =  _courseService.GetAll();
            return (IEnumerable<CourseViewModel>)courses;
        }

        public async Task<CourseViewModel> GetCourse(int courseId)
        {
            CourseModel model = await _courseService.Get(courseId);
            return model;
        }

        public async Task<CourseModel> UpdateCourse(CourseViewModel course)
        {
            CourseModel model = await _courseService.Update(course);
            return model;
        }
    }
}
