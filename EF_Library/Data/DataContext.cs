
using EF_Library.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_Library.Data;

public class DataContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_Library;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
    public DbSet<Author> Authors { get; set; }
}