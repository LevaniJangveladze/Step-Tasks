namespace EF_Relations.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    
    public StudentCard? Card { get; set; }
}