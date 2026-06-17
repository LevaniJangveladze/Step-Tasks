using ConsoleApp10.Helpers;
using ConsoleApp10.Models;

namespace ConsoleApp10.Services
{
    internal class StudentServices
    {
        private Database _db;

        public StudentServices(Database db)
        {
            _db = db;
        }

        public void CreateStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student email: ");
            string email = Console.ReadLine();

            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());

            Student student = new Student()
            {
                FullName = name,
                Email = email,
                Age = age,
            };

            _db.Students.Add(student);

            Console.WriteLine("student created successfully.");
        }

        public void DeleteStudent()
        {
            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Student? found = null;
            foreach (var item in _db.Students)
            {
                if (item.Id == id)
                {
                    found = item;
                }
            }

            if (found == null)
            {
                throw new Exception("Student not found.");
            }

            _db.Students.Remove(found);
            Console.WriteLine("student deleted successfully.");
        }

        public void UpdateStudent()
        {
            Console.Write("Enter student id: ");
            int id = int.Parse(Console.ReadLine());

            Student? found = null;
            foreach (var item in _db.Students)
            {
                if (item.Id == id)
                {
                    found = item;
                }
            }

            if (found == null)
            {
                throw new Exception("Student not found.");
            }

            Console.WriteLine("Enter new name (leave blank to keep): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                found.FullName = name;
            }

            Console.WriteLine("Enter new email (leave blank to keep): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
            {
                found.Email = email;
            }

            Console.WriteLine("Enter new age (leave blank to keep): ");
            string ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                found.Age = int.Parse(ageInput);
            }

            Console.WriteLine("student updated successfully.");
        }
    


public void ShowStudents()
        {
            foreach (var item in _db.Students)
            {
                Console.WriteLine($"STUDENT ID: {item.Id}, name: {item.FullName}, email: {item.Email}, age: {item.Age}");
            }
        }
    }
}
