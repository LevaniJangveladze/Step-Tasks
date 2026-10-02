using EF_OneToOne.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_OneToOne.Data;

public class DataContext : DbContext
{
   public DbSet<Product> Products { get; set; }
   public DbSet<ProductDetails> ProductDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_OneToOne;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
}