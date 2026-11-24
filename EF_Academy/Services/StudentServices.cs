using EF_Academy.Data;
using EF_Academy.Models;

namespace EF_Academy.Services;

public class StudentServices
{
    
    private readonly DataContext _db;
    public StudentServices(DataContext db)
    {
        _db = db;
    }
    public void create()
    {
        Console.Write("Enter student fullname: ");
        string fullName = Console.ReadLine();
        
        Console.Write("Enter student email: ");
        string email = Console.ReadLine();
        
        Console.Write("Enter student phone number: ");
        string phoneNumber = Console.ReadLine();

        var student = new Student
        {
           FullName = fullName,
           Email = email,
           PhoneNumber = phoneNumber
        };
        
        _db.Students.Add(student);
        _db.SaveChanges();
    }
}