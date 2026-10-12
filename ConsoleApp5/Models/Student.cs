namespace ConsoleApp5.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Enrollment> Enrollments { get; set; } = [];

        public void Show()
        {
            Console.WriteLine($"ID: {Id}, fullname: {Fullname}, email: {Email}, phone: {PhoneNumber}");
        }
    }
}
