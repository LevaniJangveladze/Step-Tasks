using EF_Hotel.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Hotel.Data;

public class DataContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Passport> Passports { get; set; }
    public DbSet<Room> Rooms { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EF_Hotel;User Id=sa;Password=Pihafej&77;TrustServerCertificate=True;");
    }
}