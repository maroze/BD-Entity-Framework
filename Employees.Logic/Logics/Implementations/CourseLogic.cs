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
        public CourseModel AddCourse(CourseViewModel course)
        {
            CourseModel model = course;

            return _courseService.AddCourse(model);
        }

        public IEnumerable<CourseViewModel> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public CourseViewModel GetCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseModel> UpdateCourse(CourseViewModel course)
        {
            throw new NotImplementedException();
        }
    }
}
