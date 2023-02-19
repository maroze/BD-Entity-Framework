using Employees.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class CourseRepository : BaseRepository<CourseEntityModel>, ICourseRepository
    {
        public CourseRepository(SchoolContext _courseContext) : base(_courseContext)
        {
        }

        public async Task<CourseEntityModel> GetCourse(int courseId)
        {
            var result = await GetQuery().Include(d => d.Department)
                  .FirstOrDefaultAsync(c => c.CourseID == courseId);


            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Модуль не найден");
            }

        }

        public IEnumerable<CourseEntityModel> GetCourses()
        {
            return GetAll().ToList();
        }

        public Task<CourseEntityModel> AddCourse(CourseEntityModel course)
        {
            Insert(course);

            return Task.FromResult(course);
        }

        public async Task<CourseEntityModel> UpdateCourse(CourseEntityModel course)
        {
            await UpdateAsync(course);

            return course;
        }

        public async Task<CourseEntityModel> DeleteCourse(int courseId)
        {
            var result = await GetQuery()
                .FirstOrDefaultAsync(c => c.CourseID == courseId);

            if (result != null)
            {
                Delete(result);

                return result;
            }
            return null;
        }

    }
}
