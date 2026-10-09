namespace EF_Hotel.Model;

public class Booking
{
    public int Id { get; set; }
    public DateTime BookedDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    
    public int RoomId { get; set; }
    public Room? Room { get; set; }

    public int GuestId { get; set; }
    public Guest? Guest { get; set; }
    
}