using ConsoleApp12.Common;
using ConsoleApp12.Models;

namespace ConsoleApp12.Services
{
    internal sealed class CourseServices
    {
        private Database _db;

        public CourseServices(Database db) => _db = db;

        public void Create()
        {
            Console.Write("Enter course name: ");
            string name = Console.ReadLine();

            Console.Write("Enter course description: ");
            string desc = Console.ReadLine();

            Course course = Course.Create(name, desc);
            _db.Courses.Add(course);
            Result.Success("course created");
        }

        public void Delete()
        {
            Console.Write("Enter course ID: ");
            int id = int.Parse(Console.ReadLine());

            Course? course = _db.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                throw new Exception("course not found");

            _db.Courses.Remove(course);
            Result.Success("course deleted");
        }

        public void Update()
        {
            Console.Write("Enter course ID: ");
            int id = int.Parse(Console.ReadLine());

            Course? course = _db.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                throw new Exception("course not found");

            Console.Write("Enter new name (leave blank to keep): ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                name = course.Name;

            Console.Write("Enter new description (leave blank to keep): ");
            string desc = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(desc))
                desc = course.Description;

            Course updated = Course.Create(name, desc);
            _db.Courses.Remove(course);
            _db.Courses.Add(updated);
            Result.Success("course updated");
        }

        public void Show()
        {
            foreach (var course in _db.Courses)
                course.ShowInfo();
        }

        public void Filter()
        {
            Console.Write("Search by name: ");
            string search = Console.ReadLine();

            var filtered = _db.Courses.Where(c => c.Name.Contains(search)).ToList();
            foreach (var course in filtered)
                course.ShowInfo();
        }

        public void AddStudent()
        {
            Console.Write("Enter course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            Course? course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new Exception("course not found");

            Console.Write("Enter student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Student? student = _db.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                throw new Exception("student not found");

            course.AddStudent(student);
            Result.Success("student added to course");
        }

        public void RemoveStudent()
        {
            Console.Write("Enter course ID: ");
            int courseId = int.Parse(Console.ReadLine());
            Course? course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new Exception("course not found");

            Console.Write("Enter student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            course.RemoveStudent(studentId);
            Result.Success("student removed from course");
        }
    }
}