using Employees.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class StudentRepository : BaseRepository<StudentEntityModel>, IStudentRepository
    {
        public StudentRepository(SchoolContext _studentContext) : base(_studentContext)
        {
        }

        public async Task<StudentEntityModel> GetStudent(int studentId)
        {
            var result =  await GetQuery()
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == studentId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Студент не найден");
            }
        }

        public IEnumerable<StudentEntityModel> GetStudents()
        {
            return GetAll().ToList();
        }

        public Task<StudentEntityModel> AddStudent(StudentEntityModel student)
        {
            Insert(student);
            return Task.FromResult(student);
        }

        public async Task<StudentEntityModel> UpdateStudent(StudentEntityModel student)
        {
                await UpdateAsync(student);

                return student;
        }

        public async Task<StudentEntityModel> DeleteStudent(int studentId)
        {
            var result = await GetQuery()
                 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == studentId);

            if (result != null)
            {
                Delete(result);

                return result;
            }
            return null;
        }

    }
}
