using EF_Hotel.Data;
using EF_Hotel.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Hotel.Services;

public class BookingService
{
    private readonly DataContext _context;

    public BookingService(DataContext context)
    {
        _context = context;
    }

    public void CreateBooking(int guestId, int roomId, DateTime checkIn, DateTime checkOut)
    {
        var guest =  _context.Guests.Find(guestId);
        if (guest == null) throw new Exception("Guest not found");
        var room = _context.Rooms.Find(roomId);
        if (room == null) throw new Exception("Room not found");
        if (checkOut <= checkIn)
            throw new Exception("Check-out must be after check-in");
        bool isTaken = _context.Bookings.Any(b => 
            b.RoomId == roomId && b.CheckInDate < checkOut && b.CheckOutDate > checkIn);
        if (isTaken) throw new Exception("Room is already booked for these dates");

        var booking = new Booking
        {
            GuestId = guestId,
            RoomId = roomId,
            BookedDate = DateTime.Now,
            CheckInDate = checkIn.Date,
            CheckOutDate = checkOut.Date
        };
        
        _context.Bookings.Add(booking);
        _context.SaveChanges();
    }
    
    public List<Booking> GetAllBookings()
    {
        return _context.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .ToList();
    }
}