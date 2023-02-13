using Employees.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _courseContext;

        public CourseRepository(SchoolContext _courseContext)
        {
            this._courseContext = _courseContext;
        }

        public async Task<CourseEntityModel> GetCourse(int courseId)
        {
            return await _courseContext.Courses
                .Include(d => d.Department)
                  .FirstOrDefaultAsync(c => c.CourseID == courseId);
        }

        public async Task<IEnumerable<CourseEntityModel>> GetCourses()
        {
            return await _courseContext.Courses.ToListAsync();
        }

        public async Task<CourseEntityModel> AddCourse(CourseEntityModel course)
        {
            var result = await _courseContext.Courses.AddAsync(course);
            await _courseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CourseEntityModel> UpdateCourse(CourseEntityModel course)
        {
            var result = await _courseContext.Courses
                .FirstOrDefaultAsync(c => c.CourseID == course.CourseID);

            if (result != null)
            {
                result.Title = course.Title;
                result.Credits = course.Credits;
                result.DepartmentID = course.DepartmentID;

                await _courseContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteCourse(int courseId)
        {
            var result = await _courseContext.Courses
                .Include(d => d.Department)
                .FirstOrDefaultAsync(c => c.CourseID == courseId);
            if (result != null)
            {
                _courseContext.Courses.Remove(result);
                await _courseContext.SaveChangesAsync();
            }
        }

    }
}
