using ConsoleApp12.Common;

namespace ConsoleApp12.Models
{
    internal sealed class Student : Entity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }

        private Student(string fullName, string email, int age)
        {
            FullName = fullName;
            Email = email;
            Age = age;
        }

        public static Student Create(string fullName, string email, int age)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new Exception("student full name is required");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("student email is required");

            if (!email.Contains("@") || !email.Contains("."))
                throw new Exception("student email invalid format");

            if (age < 18 || age > 70)
                throw new Exception("student must be greater then 18 and lower then 70");

            return new Student(fullName, email, age);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {FullName}, email: {Email}, age: {Age}");
        }
    }
}
