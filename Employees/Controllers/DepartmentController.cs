using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employees.Data;
using Employees.Entities;
using Employees.Services.Services;
using Employees.Common.ViewModels;

namespace Employees.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly SchoolContext departmentEntity;

        public DepartmentController(IDepartmentService departmentService, SchoolContext departmentEntity)
        {
            _departmentService = departmentService;
            this.departmentEntity = departmentEntity;
        }

        public async Task<IActionResult> Index()
        {
            return View(await departmentEntity.Departments.ToListAsync());
        }

        // GET: Department/Details/5
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var departmentEntityModel = _departmentService.Get(id);
            if (departmentEntityModel == null)
            {
                return NotFound();
            }

            return View(departmentEntityModel);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                return Ok(_departmentService.GetAll());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("AddDepartment")]
        public IActionResult Create([FromBody] DepartmentViewModel department)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var createdDepartment = _departmentService.Add(department);

                return Created($"/api/department/{createdDepartment}", createdDepartment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateDepartment")]
        public IActionResult Edit([FromBody] DepartmentViewModel department)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Invalid request data");

                var updatedDepartment = _departmentService.Update(department);

                return Ok(updatedDepartment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete( [FromRoute] int departmentId)
        {
            try
            {
                _departmentService.Delete(departmentId);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //private readonly SchoolContext _context;

        //public DepartmentController(SchoolContext context)
        //{
        //    _context = context;
        //}

        //// GET: Department
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Departments.ToListAsync());
        //}

        //// GET: Department/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var departmentEntityModel = await _context.Departments
        //        .FirstOrDefaultAsync(m => m.DepartmentID == id);
        //    if (departmentEntityModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(departmentEntityModel);
        //}

        //// GET: Department/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Department/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("DepartmentID,Name,Budget,StartDate,InstructorID")] DepartmentEntityModel departmentEntityModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(departmentEntityModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(departmentEntityModel);
        //}

        //// GET: Department/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var departmentEntityModel = await _context.Departments.FindAsync(id);
        //    if (departmentEntityModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(departmentEntityModel);
        //}

        //// POST: Department/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,Name,Budget,StartDate,InstructorID")] DepartmentEntityModel departmentEntityModel)
        //{
        //    if (id != departmentEntityModel.DepartmentID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(departmentEntityModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DepartmentEntityModelExists(departmentEntityModel.DepartmentID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(departmentEntityModel);
        //}

        //// GET: Department/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var departmentEntityModel = await _context.Departments
        //        .FirstOrDefaultAsync(m => m.DepartmentID == id);
        //    if (departmentEntityModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(departmentEntityModel);
        //}

        //// POST: Department/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var departmentEntityModel = await _context.Departments.FindAsync(id);
        //    _context.Departments.Remove(departmentEntityModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DepartmentEntityModelExists(int id)
        //{
        //    return _context.Departments.Any(e => e.DepartmentID == id);
        //}
    }
}
