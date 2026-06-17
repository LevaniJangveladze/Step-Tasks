using ConsoleApp10.Common;

namespace ConsoleApp10.Models
{
    internal class Course : Entity
    {
        public string Name { get; set; }
        public int MinAge { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
