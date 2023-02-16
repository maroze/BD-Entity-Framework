using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employees.Data;
using Employees.Entities;
using Employees.Services;
using Employees.Services.Models;
using Employees.Logic.Logics;
using Employees.Common.ViewModels;

namespace Employees.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            try
            {
                return Ok(_courseService.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] CourseViewModel course)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var createdCourse = _courseService.Add(course);

                return Created($"/api/course/{createdCourse}", createdCourse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] CourseViewModel course)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var updatedCourse = _courseService.Update(course);

                return Ok(updatedCourse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse( [FromRoute] int courseId)
        {
            try
            {
                _courseService.Delete(courseId);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        
        //// GET: Courses
        //public async Task<IActionResult> Index(
        //    string sortOrder,
        //    string currentFilter,
        //    string searchString,
        //    int? pageNumber)
        //{
        //    ViewData["CurrentSort"] = sortOrder;

        //    ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        //    ViewData["CreditSortParm"] = sortOrder == "Credit" ? "credit_desc" : "Credit";

        //    if (searchString != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewData["CurrentFilter"] = searchString;
        //    var courses = from c in _context.Courses
        //                  select c;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {

        //        courses = courses.Where(c => c.Title.Contains(searchString));

        //    }
        //    switch (sortOrder)
        //    {
        //        case "title_desc":
        //            courses = courses.OrderByDescending(c => c.Title);
        //            break;
        //        case "Credit":
        //            courses = courses.OrderBy(c => c.Credits);
        //            break;
        //        case "credit_desc":
        //            courses = courses.OrderByDescending(c => c.Credits);
        //            break;
        //        default:
        //            courses = courses.OrderBy(c => c.Title);
        //            break;
        //    }
        //    int pageSize = 4;
        //    return View(await PaginatedList<Course>.CreateAsync(courses.Include(c => c.Department).AsNoTracking(), pageNumber ?? 1, pageSize));

        //}

        //// GET: Courses/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses
        //        .Include(c => c.Department)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.CourseID == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(course);
        //}

        //// GET: Courses/Create
        //public IActionResult Create()
        //{
        //    PopulateDepartmentsDropDownList();
        //    return View();
        //}

        //// POST: Courses/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CourseID,Credits,DepartmentID,Title")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(course);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(course);
        //}

        //// GET: Courses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.CourseID == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(course);
        //}

        //// POST: Courses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var courseToUpdate = await _context.Courses
        //            .FirstOrDefaultAsync(c => c.CourseID == id);

        //    if (await TryUpdateModelAsync<Course>(courseToUpdate,
        //        "",
        //        c => c.Credits, c => c.DepartmentID, c => c.Title))
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {

        //            ModelState.AddModelError("", "Не удалось сохранить изменения. ");
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
        //    return View(courseToUpdate);
        //}

        ///// <summary>
        /////Метод загружающий сведения о кафедре для раскрывающегося списка.
        ///// </summary>
        ///// <param name="selectedDepartment"></param>
        //private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        //{
        //    var departmentsQuery = from d in _context.Departments
        //                           orderby d.Name
        //                           select d;
        //    ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        //}
        //// GET: Courses/Delete/5
        //public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _context.Courses
        //         .Include(c => c.Department)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.CourseID == id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    if (saveChangesError.GetValueOrDefault())
        //    {
        //        ViewData["ErrorMessage"] =
        //            "Не удалось произвести удаление. Попробуйте еще раз ";
        //    }
        //    return View(course);
        //}

        //// POST: Courses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    try
        //    {

        //        _context.Courses.Remove(course);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
        //    }
        //}

        //private bool CourseExists(int id)
        //{
        //    return _context.Courses.Any(e => e.CourseID == id);
        //}
    }
}
