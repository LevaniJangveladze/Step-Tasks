using EF_Hotel.Data;
using EF_Hotel.Model;
using EF_Hotel.Services;

using var db = new DataContext();

var guestService = new GuestService(db);
var roomService = new RoomService(db);
var bookingService = new BookingService(db);

// 1. create the guest
Console.Write("Enter guest fullname: ");
string fullName = Console.ReadLine();

Console.Write("Enter guest email: ");
string email = Console.ReadLine();

Console.Write("Enter guest phone: ");
string phone = Console.ReadLine();

Console.Write("Enter passport number: ");
string passportNumber = Console.ReadLine();

var guest = new Guest
{
    FullName = fullName,
    Email = email,
    PhoneNumber = phone,
    Passport = new Passport
    {
        FullName = fullName,
        IdentityNumber = passportNumber
    }
};

guestService.AddGuest(guest);
Console.WriteLine($"Guest saved with id {guest.Id}");

var room = new Room
{
    RoomNumber = "101",
    Price = 150,
    Capacity = 2
};

roomService.AddRoom(room);
Console.WriteLine($"Room saved with id {room.Id}");


bookingService.CreateBooking(guest.Id, room.Id, new DateTime(2026, 11, 1), new DateTime(2026, 11, 5));
Console.WriteLine("Booking created");


Console.WriteLine("\nAll bookings:");
foreach (var b in bookingService.GetAllBookings())
    Console.WriteLine($"{b.Guest.FullName} — room {b.Room.RoomNumber} — {b.CheckInDate:d} to {b.CheckOutDate:d}");


try
{
    bookingService.CreateBooking(guest.Id, room.Id, new DateTime(2026, 11, 2), new DateTime(2026, 11, 4));
    Console.WriteLine("Second booking created — the overlap check did not work");
}
catch (Exception ex)
{
    Console.WriteLine($"\nRejected as expected: {ex.Message}");
}