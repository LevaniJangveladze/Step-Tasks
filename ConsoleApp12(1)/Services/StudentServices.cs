using ConsoleApp12.Common;
using ConsoleApp12.Models;

namespace ConsoleApp12.Services
{
    internal sealed class StudentServices
    {
        private Database _db;

        public StudentServices(Database db) => _db = db;

        public void Create()
        {
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Student student = Student.Create(fullName, email, age);
            _db.Students.Add(student);
            Result.Success("student created");
        }

        public void Delete()
        {
            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Student? student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                throw new Exception("student not found");

            _db.Students.Remove(student);
            Result.Success("student deleted");
        }

        public void Update()
        {
            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Student? student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                throw new Exception("student not found");

            Console.Write("Enter new full name (leave blank to keep): ");
            string fullName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fullName))
                fullName = student.FullName;

            Console.Write("Enter new email (leave blank to keep): ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
                email = student.Email;

            Console.Write("Enter new age (leave blank to keep): ");
            string ageInput = Console.ReadLine();
            int age = string.IsNullOrWhiteSpace(ageInput) ? student.Age : int.Parse(ageInput);

            // rebuild through the factory so validation still runs
            Student updated = Student.Create(fullName, email, age);
            _db.Students.Remove(student);
            _db.Students.Add(updated);
            Result.Success("student updated");
        }

        public void Show()
        {
            foreach (var student in _db.Students)
                student.ShowInfo();
        }

        public void Filter()
        {
            Console.Write("Enter max age: ");
            int maxAge = int.Parse(Console.ReadLine());

            var filtered = _db.Students.Where(s => s.Age <= maxAge).ToList();
            foreach (var student in filtered)
                student.ShowInfo();
        }
    }
}