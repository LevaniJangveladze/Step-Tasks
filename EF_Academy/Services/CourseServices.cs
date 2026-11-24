using EF_Academy.Data;
using EF_Academy.Models;

namespace EF_Academy.Services;

public class CourseServices
{
    private readonly DataContext _db;
    public CourseServices(DataContext db)
    {
        _db = db;
    }

    public void Create()
    {
        Console.Write("Enter course name: ");
        string courseName = Console.ReadLine();
        
        Console.Write("Enter course capacity: ");
        string courseCapacity = Console.ReadLine();
        
        Console.Write("Enter course deadline: ");
        int deadLine = int.Parse(Console.ReadLine()!);
        
        Console.Write("Enter course lesson count: ");
        int lessonCount = int.Parse(Console.ReadLine()!);
        
        var course = new Course
        {
            Name = name;
                Capacity = capacity;
                
        }
    }
}