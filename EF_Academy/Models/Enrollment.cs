namespace EF_Academy.Models;

public class Enrollment
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime RegisterTime { get; set; }
}