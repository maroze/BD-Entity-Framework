using Employees.Data.Entities;
using Employees.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<CourseEntityModel> Courses { get; set; }
        public DbSet<EnrollmentEntityModel> Enrollments { get; set; }
        public DbSet<StudentEntityModel> Students { get; set; }
        public DbSet<DepartmentEntityModel> Departments { get; set; }
        public DbSet<InstructorEntityModel> Instructors { get; set; }
        public DbSet<OfficeAssignmentEntityModel> OfficeAssignments { get; set; }
        public DbSet<CourseAssignmentEntityModel> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntityModel>().ToTable("Course");
            modelBuilder.Entity<EnrollmentEntityModel>().ToTable("Enrollment");
            modelBuilder.Entity<StudentEntityModel>().ToTable("Student");
            modelBuilder.Entity<DepartmentEntityModel>().ToTable("Department");
            modelBuilder.Entity<InstructorEntityModel>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignmentEntityModel>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignmentEntityModel>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssignmentEntityModel>()
                .HasKey(c => new { c.CourseID, c.InstructorID });

        }
    }
}
