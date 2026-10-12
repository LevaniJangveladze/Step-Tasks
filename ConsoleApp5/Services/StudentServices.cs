using ConsoleApp5.Data;
using ConsoleApp5.Models;

namespace ConsoleApp5.Services
{
    internal class StudentServices
    {
        private readonly DataContext _db;

        public StudentServices(DataContext db)
        {
            _db = db;
        }

        public void Create()
        {
            Console.Write("Enter student fullname: ");
            string fullname = Console.ReadLine()!;

            Console.Write("Enter student email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter student phone number: ");
            string phoneNumber = Console.ReadLine()!;

            var student = new Student
            {
                Email = email,
                Fullname = fullname,
                PhoneNumber = phoneNumber,
            };

            _db.Students.Add(student);
            _db.SaveChanges();
        }
    }
}
