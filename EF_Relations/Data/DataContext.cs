using EF_Relations.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Relations.Data;

public class DataContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCard> StudentCards { get; set; }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_Relations;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
}