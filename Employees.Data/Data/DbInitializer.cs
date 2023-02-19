using Employees.Data.Entities;
using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();


            //if (context.Students.Any())
            //{
            //    return;
            //}

            var students = new StudentEntityModel[]
            {
                new StudentEntityModel { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new StudentEntityModel { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new StudentEntityModel { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new StudentEntityModel { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new StudentEntityModel { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new StudentEntityModel { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new StudentEntityModel { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new StudentEntityModel { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (StudentEntityModel s in students)
            {
               // context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new InstructorEntityModel[]
            {
                new InstructorEntityModel { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new InstructorEntityModel { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new InstructorEntityModel { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new InstructorEntityModel { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new InstructorEntityModel { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (InstructorEntityModel i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new DepartmentEntityModel[]
            {
                new DepartmentEntityModel { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new DepartmentEntityModel { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new DepartmentEntityModel { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new DepartmentEntityModel { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (DepartmentEntityModel d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new CourseEntityModel[]
            {
                new CourseEntityModel {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new CourseEntityModel {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new CourseEntityModel {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new CourseEntityModel {CourseID = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new CourseEntityModel {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new CourseEntityModel {CourseID = 2021, Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new CourseEntityModel {CourseID = 2042, Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };

            foreach (CourseEntityModel c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignmentEntityModel[]
            {
                new OfficeAssignmentEntityModel {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignmentEntityModel {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignmentEntityModel {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignmentEntityModel o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignmentEntityModel[]
            {
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignmentEntityModel {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (CourseAssignmentEntityModel ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new EnrollmentEntityModel[]
            {
                new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                    },
                new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                    },
                    new EnrollmentEntityModel {
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (EnrollmentEntityModel e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                           // s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}

