using ConsoleApp10.Common;

namespace ConsoleApp10.Models
{
    internal class Student : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
