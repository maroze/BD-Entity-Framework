using Employees.Data.Repository;
using Employees.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository _studentRepository)
        {
            this._studentRepository = _studentRepository;
        }

        public async Task<StudentModel> Add(StudentModel student)
        {
            var result = await _studentRepository.AddStudent(student);
            return result;
        }

        public async Task<StudentModel> Delete(int studentId)
        {
            var result = await _studentRepository.DeleteStudent(studentId);
            return result;
        }

        public async Task<StudentModel> Get(int studentId)
        {
            var result = await _studentRepository.GetStudent(studentId);
            return result;
        }

        public IEnumerable<StudentModel> GetAll()
        {
            List<StudentModel> result = new List<StudentModel>();
            var student_list = _studentRepository.GetStudents();
            foreach (var s in student_list)
            {

                result.Add(s);
            }

            return result;
        }

        public async Task<StudentModel> Update(StudentModel student)
        {
            var result = await _studentRepository.UpdateStudent(student);
            return result;
        }
    }
}
