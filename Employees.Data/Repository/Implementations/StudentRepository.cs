using Employees.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _studentContext;

        public StudentRepository(SchoolContext _studentContext)
        {
            this._studentContext = _studentContext;
        }

        public async Task<StudentEntityModel> GetStudent(int studentId)
        {
            return await _studentContext.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == studentId);
        }

        public async Task<IEnumerable<StudentEntityModel>> GetStudents()
        {
            return await _studentContext.Students.ToListAsync();
        }

        public async Task<StudentEntityModel> AddStudent(StudentEntityModel student)
        {
            var result = await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<StudentEntityModel> UpdateStudent(StudentEntityModel student)
        {

            var result = await _studentContext.Students.FirstOrDefaultAsync(s => s.ID == student.ID);

                if (result != null)
            {
                result.FirstMidName = student.FirstMidName;
                result.LastName = student.LastName;
                result.EnrollmentDate = student.EnrollmentDate;

                await _studentContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteStudent(int studentId)
        {
            var result = await _studentContext.Students
                 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == studentId);
            if (result != null)
            {
                _studentContext.Students.Remove(result);
                await _studentContext.SaveChangesAsync();
            }
        }

    }
}
