//using Employees.Data;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Employees.Logic.Logics
//{
//    class StudentLogic
//    {
//        private readonly SchoolContext _context;

//        public StudentsController(SchoolContext context)
//        {
//            _context = context;
//        }
//        // GET: Students
//        public async Task<IActionResult> Index(
//            string sortOrder,
//            string currentFilter,
//            string searchString,
//            int? pageNumber)
//        {
//            ViewData["CurrentSort"] = sortOrder;

//            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

//            if (searchString != null)
//            {
//                pageNumber = 1;
//            }
//            else
//            {
//                searchString = currentFilter;
//            }

//            ViewData["CurrentFilter"] = searchString;
//            var students = from s in _context.Students
//                           select s;

//            if (!String.IsNullOrEmpty(searchString))
//            {

//                students = students.Where(s => s.LastName.Equals(searchString) || s.FirstMidName.Contains(searchString));

//            }

//            switch (sortOrder)
//            {
//                case "name_desc":
//                    students = students.OrderByDescending(s => s.LastName);
//                    break;
//                case "Date":
//                    students = students.OrderBy(s => s.EnrollmentDate);
//                    break;
//                case "date_desc":
//                    students = students.OrderByDescending(s => s.EnrollmentDate);
//                    break;
//                default:
//                    students = students.OrderBy(s => s.LastName);
//                    break;
//            }
//            int pageSize = 3;
//            return View(await PaginatedList<StudentEntityModel>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
//        }

//        // GET: Students/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            //Методы Include и ThenInclude инструктируют контекст
//            //для загрузки свойства навигации Student.Enrollments,
//            //а также свойства навигации Enrollment.Course
//            var student = await _context.Students
//                .Include(s => s.Enrollments)
//                    .ThenInclude(e => e.Course)
//                .AsNoTracking()
//                .FirstOrDefaultAsync(m => m.ID == id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // GET: Students/Create
//        public IActionResult Create()
//        {
//            return View();
//        }


//        // GET: Students/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // GET: Students/Delete/5
//        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)

//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                 //метод AsNoTracking() отключает отслеживание
//                 //объектов сущностей в памяти
//                 .AsNoTracking()
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            if (saveChangesError.GetValueOrDefault())
//            {
//                ViewData["ErrorMessage"] =
//                    "Не удалось произвести удаление. Попробуйте еще раз ";
//            }
//            return View(student);
//        }

//    }
//}
