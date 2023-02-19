using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class InstructorRepository : BaseRepository<InstructorEntityModel>, IInstructorRepository
    {
        public InstructorRepository(SchoolContext _instructorContext) : base(_instructorContext)
        {
        }
        public Task<InstructorEntityModel> AddInstructor(InstructorEntityModel instructor)
        {
            throw new NotImplementedException();
        }

        public Task<InstructorEntityModel> DeleteInstructor(int instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<InstructorEntityModel> GetInstructor(int instructorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InstructorEntityModel> GetInstructors()
        {
            throw new NotImplementedException();
        }

        public Task<InstructorEntityModel> UpdateInstructor(InstructorEntityModel instructor)
        {
            throw new NotImplementedException();
        }
    }
}
