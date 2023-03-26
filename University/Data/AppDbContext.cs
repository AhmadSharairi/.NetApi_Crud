using Microsoft.EntityFrameworkCore;

using University.Models;

namespace University.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }


        public DbSet<student> Students { get; set; }
        public DbSet<course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     // Fluent API : Object-Relational Mapping (ORM)
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });


            modelBuilder.Entity<StudentCourse>()
            .HasOne<student>(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId).
            OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<StudentCourse>()
            .HasOne<course>(sc => sc.Course)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.CourseId).
            OnDelete(DeleteBehavior.ClientSetNull);




        }
    }
}
