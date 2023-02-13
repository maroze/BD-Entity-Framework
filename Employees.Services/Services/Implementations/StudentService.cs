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

        public StudentModel AddStudent(StudentModel student)
        {
            var result = _studentRepository.AddStudent(student);
            return result;
        }

        public StudentModel DeleteStudent(int studentId)
        {
            var result = _studentRepository.DeleteStudent(studentId);
            return result;
        }

        public StudentModel GetStudent(int studentId)
        {
            object result = _studentRepository.GetStudent(studentId);
            return result;
        }

        public IEnumerable<StudentModel> GetStudents()
        {
            var student_list = _studentRepository.GetStudents();
            IEnumerable<StudentModel> result = new IEnumerable<StudentModel>();

            foreach (var s in student_list)
            {

                result.Add(s);
            }

            return result;
        }

        public Task<StudentModel> UpdateStudent(StudentModel student)
        {
            var result = _studentRepository.UpdateStudent(student);
            return result;
        }
    }
}
