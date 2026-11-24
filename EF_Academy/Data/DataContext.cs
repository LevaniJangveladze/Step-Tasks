using EF_Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Academy.Data;

public class DataContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_Academy;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(s =>
        {   s.Property(x => x.FullName).HasMaxLength(50);
            s.HasIndex(x => x.Email).IsUnique();
            s.HasIndex(x => x.PhoneNumber).IsUnique();
        });

        modelBuilder.Entity<Course>(c =>
        {
            c.Property(x => x.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Enrollment>(e =>
        {
            e.HasKey(x => new { x.StudentId, x.CourseId });
        });
    }
}