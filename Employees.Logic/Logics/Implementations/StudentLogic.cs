using Employees.Common.ViewModels;
using Employees.Data;
using Employees.Services.Models;
using Employees.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Logic.Logics
{
    public class StudentLogic: IStudentLogic
    {
        private readonly IStudentService _studentService;

        public StudentLogic(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }

        public Task<StudentModel> AddStudent(StudentViewModel student)
        {
            StudentModel model = student;
            return await _studentService.Add(model);
        }

        public Task<StudentModel> DeleteStudent(int studentId)
        {
            StudentModel model = await _studentService.Delete(studentId);
            return model;
        }

        public Task<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            var students = await _studentService.GetAll();
            return students;
        }

        public Task<StudentViewModel> GetStudent(int courseId)
        {
            StudentModel model = await _studentService.Get(courseId);
            return model;
        }

        public Task<StudentModel> UpdateStudent(StudentViewModel student)
        {
            StudentModel model = await _studentService.UpdateStudent(student);
            return model;
        }
    }
}
