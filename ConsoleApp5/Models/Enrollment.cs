namespace ConsoleApp5.Models
{
    internal class Enrollment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.Now;
    }
}
