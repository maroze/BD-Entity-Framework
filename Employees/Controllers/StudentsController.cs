using Employees.Data;
using Employees.Entities;
using Employees.Services.Models;
using Employees.Services.Services;
using Employees.Common.ViewModels;
using Employees.Logic.Logics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService _studentService)
        {
            this._studentService = _studentService;
        }

        /// <summary>
        /// Получает все сущности Student,
        /// из набор сущностей Students
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpGet("GetStudents"), ActionName("Index")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_studentService.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Добавляет сущность Student, созданную связывателем модели ASP.NET Core MVC, 
        /// в набор сущностей Students и сохраняет изменения в БД. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("AddCourse")]
        public IActionResult Add([FromBody] StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var createdStudent = _studentService.Add(student);

                return Created($"/api/course/{createdStudent}", createdStudent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Изменяет сущность Student,
        /// в набор сущностей Students и сохраняет изменения в БД. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("UpdateStudent")]
        public IActionResult Update([FromBody] StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var updatedStudent = _studentService.Update(student);

                return Ok(updatedStudent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Удаляет сущность Student, 
        /// из набора сущностей Students и сохраняет изменения в БД. 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpDelete("DeleteStudent")]
        public IActionResult Delete([FromRoute] int studentId)
        {
            try
            {
                _studentService.Delete(studentId);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    //    // POST: Students/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    /// <summary>
    //    /// Добавляет сущность Student, созданную связывателем модели ASP.NET Core MVC, 
    //    /// в набор сущностей Students и сохраняет изменения в БД. 
    //    /// </summary>
    //    /// <param name="student"></param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(
    //        [Bind("EnrollmentDate,FirstMidName,LastName")] StudentEntityModel student)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _context.Add(student);
    //                await _context.SaveChangesAsync();
    //                return RedirectToAction(nameof(Index));
    //            }
    //        }
    //        catch (DbUpdateException /* ex */)
    //        {
    //            //Зарегистрировать ошибку (чтобы зарегестрировать исключение в журнал надо раскоммен-ть ex)
    //            ModelState.AddModelError("", "Не удалось сохранить изменения. ");
    //        }
    //        return View(student);
    //    }


    //    // POST: Students/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost, ActionName("Edit")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> EditPost(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }
    //        var studentToUpdate = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
    //        //Пустая строка перед списком полей предназначена
    //        //для префикса, который используется с именами полей формы
    //        if (await TryUpdateModelAsync<StudentEntityModel>(
    //            studentToUpdate,
    //            "",
    //            s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
    //        {
    //            try
    //            {
    //                await _context.SaveChangesAsync();
    //                return RedirectToAction(nameof(Index));
    //            }
    //            catch (DbUpdateException /* ex */)
    //            {

    //                ModelState.AddModelError("", "Не удалось сохранить изменения. ");
    //            }
    //        }
    //        return View(studentToUpdate);
    //    }


    //    // POST: Students/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var student = await _context.Students.FindAsync(id);
    //        if (student == null)
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }

    //        try
    //        {
    //            _context.Students.Remove(student);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch (DbUpdateException /* ex */)
    //        {
    //            return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
    //        }
    //    }

    //    private bool StudentExists(int id)
    //    {
    //        return _context.Students.Any(e => e.ID == id);
    //    }
    }
}
