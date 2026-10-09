using EF_Hotel.Data;
using EF_Hotel.Model;

namespace EF_Hotel.Services;

public class RoomService
{
    private readonly DataContext _context;

    public RoomService(DataContext context)
    {
        _context = context;
    }

    public void AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        _context.SaveChanges();
    }

    public List<Room> GetAllRooms()
    {
        return _context.Rooms.ToList();
    }

    public Room? GetRoomById(int id)
    {
        return _context.Rooms.Find(id);
    }

    public void DeleteRoom(int id)
    {
        var room = _context.Rooms.Find(id);
        if (room == null) return;
        _context.Rooms.Remove(room);
        _context.SaveChanges();
    }
}