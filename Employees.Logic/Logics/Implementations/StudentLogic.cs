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

        public async Task<StudentModel> AddStudent(StudentViewModel student)
        {
            StudentModel model = student;
            return await _studentService.Add(model);
        }

        public async Task<StudentModel> DeleteStudent(int studentId)
        {
            StudentModel model = await _studentService.Delete(studentId);
            return model;
        }

        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            var students = _studentService.GetAll();
            return (IEnumerable<StudentViewModel>)students;
        }

        public async Task<StudentViewModel> GetStudent(int studentId)
        {
            StudentModel model = await _studentService.Get(studentId);
            return model;
        }

        public async Task<StudentModel> UpdateStudent(StudentViewModel student)
        {
            StudentModel model = await _studentService.Update(student);
            return model;
        }
    }
}
