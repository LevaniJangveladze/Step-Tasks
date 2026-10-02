using EF_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Shop.Data;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_Shop;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
} 