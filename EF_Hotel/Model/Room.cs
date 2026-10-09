namespace EF_Hotel.Model;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public Decimal Price  { get; set; }
    public int Capacity { get; set; }
    
    public List<Booking> Bookings { get; set; }

}