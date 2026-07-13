namespace ConsoleApp19.Models
{
    internal class Course
    {
        private static int _counter = 1;
        public int Id { get; private set; }
        public string Name { get;  set; }
        public string Description { get;  set; }

        public Course()
        {
            Id = _counter++;
        }
    }
}
