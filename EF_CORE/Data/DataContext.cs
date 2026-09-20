using EF_CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=EF_CORE;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
}