using EF_Hotel.Data;
using EF_Hotel.Model;

namespace EF_Hotel.Services;

public class GuestService

{
    private readonly DataContext _context;

    public GuestService(DataContext context)
    {
        _context = context;
    }

    public void AddGuest(Guest guest)
    {
        _context.Guests.Add(guest);
        _context.SaveChanges();
    }
    
    public List<Guest> GetAllGuests()
    {
        return _context.Guests.ToList();
    }

    public Guest? GetGuestById(int id)
    {
        return _context.Guests.Find(id);
    }
    
    public void DeleteGuest(int id)
    {
        var guest = _context.Guests.Find(id);
        if (guest == null) return;
        
        _context.Guests.Remove(guest);
        _context.SaveChanges();
    }
}