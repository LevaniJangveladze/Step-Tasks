using ConsoleApp5.Data;
using ConsoleApp5.Models;

namespace ConsoleApp5.Services
{
    internal class CourseServices
    {
        private readonly DataContext _db;

        public CourseServices(DataContext db)
        {
            _db = db;
        }

        public void Create()
        {
            Console.Write("Enter course name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter course capacity: ");
            int capacity = int.Parse(Console.ReadLine()!);

            Console.Write("Enter course deadline in month: ");
            int deadline = int.Parse(Console.ReadLine()!);

            Console.Write("Enter course lesson count: ");
            int lessonCount = int.Parse(Console.ReadLine()!);

            var course = new Course
            {
                Name = name,
                Capacity = capacity,
                LessonCount = lessonCount,
                Deadline = DateTime.Now.AddMonths(deadline),
            };

            _db.Courses.Add(course);
            _db.SaveChanges();
        }
    }
}
