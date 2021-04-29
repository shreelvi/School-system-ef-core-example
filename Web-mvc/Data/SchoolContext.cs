using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Web_mvc.Models;

namespace Web_mvc.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor>  Instructors{ get;  set; }
        public DbSet<CourseAssignment>  CourseAssignments{ get;  set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
             modelBuilder.Entity<Course>().ToTable("Course");
             modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
             modelBuilder.Entity<Student>().ToTable("Student");
             modelBuilder.Entity<Department>().ToTable("Department");
             modelBuilder.Entity<Instructor>().ToTable("Instructor");
             modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

             modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new {c.CourseId, c.InstructorId });
         }
    }
}