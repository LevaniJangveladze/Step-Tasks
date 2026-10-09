namespace EF_Hotel.Model;

public class Guest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  
    public Passport? Passport { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
    
}