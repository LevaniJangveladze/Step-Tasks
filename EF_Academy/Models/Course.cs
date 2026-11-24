namespace EF_Academy.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public DateTime Deadline { get; set; }
    public int LessonCount { get; set; }
    
    public List<Enrollment> Enrollments { get; set; }
}