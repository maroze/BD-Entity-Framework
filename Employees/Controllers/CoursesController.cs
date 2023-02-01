using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employees.Data;
using Employees.Models;

namespace Employees.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["CreditSortParm"] = sortOrder == "Credit" ? "credit_desc" : "Credit";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var courses = from c in _context.Courses
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {

                courses = courses.Where(c => c.Title.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "title_desc":
                    courses = courses.OrderByDescending(c => c.Title);
                    break;
                case "Credit":
                    courses = courses.OrderBy(c => c.Credits);
                    break;
                case "credit_desc":
                    courses = courses.OrderByDescending(c => c.Credits);
                    break;
                default:
                    courses = courses.OrderBy(c => c.Title);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<Course>.CreateAsync(courses.Include(c => c.Department).AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Credits")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Зарегистрировать ошибку (чтобы зарегестрировать исключение в журнал надо раскоммен-ть ex)
                ModelState.AddModelError("", "Не удалось сохранить изменения. ");
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courseToUpdate = await _context.Courses.FirstOrDefaultAsync(s => s.CourseID == id);

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "",
                s => s.Title, s => s.Credits))

            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {

                    ModelState.AddModelError("", "Не удалось сохранить изменения. ");
                }

            }
            return View(courseToUpdate);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                  .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Не удалось произвести удаление. Попробуйте еще раз ";
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
