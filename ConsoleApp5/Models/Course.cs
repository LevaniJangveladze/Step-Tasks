namespace ConsoleApp5.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime Deadline { get; set; }
        public int LessonCount { get; set; }

        public List<Enrollment> Enrollments { get; set; } = [];

        public void Show()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, capacity: {Capacity}, deadline: {Deadline}, lesson count: {LessonCount}");
        }
    }
}
