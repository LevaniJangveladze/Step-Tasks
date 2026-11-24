namespace EF_Academy.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<Enrollment> Enrollments { get; set; } = [];
}