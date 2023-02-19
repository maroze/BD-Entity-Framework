using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repository.Implementations
{
    public class OfficeAssignmentRepository : BaseRepository<OfficeAssignmentEntityModel>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(SchoolContext _oaContext) : base(_oaContext)
        {
        }
        public Task<OfficeAssignmentEntityModel> AddOfficeAssignment(OfficeAssignmentEntityModel oa)
        {
            throw new NotImplementedException();
        }

        public Task<OfficeAssignmentEntityModel> UpdateOfficeAssignment(OfficeAssignmentEntityModel oa)
        {
            throw new NotImplementedException();
        }
    }
}
