using ConsoleApp5.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp5.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Academy;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(x => x.Id);

                student.Property(x => x.Fullname).HasMaxLength(64);

                student.HasIndex(x => x.Email).IsUnique();
                student.HasIndex(x => x.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.HasKey(x => x.Id);

                course.Property(x => x.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<Enrollment>(enrollment =>
            {
                enrollment.HasKey(x => new { x.StudentId, x.CourseId });
            });
        }
    }
}
