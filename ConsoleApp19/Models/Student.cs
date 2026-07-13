namespace ConsoleApp19.Models
{
    internal class Student
    {
        private static int _counter = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int CourseId { get; set; }

        public Student()
        {
            Id = _counter++;
        }
    }
}