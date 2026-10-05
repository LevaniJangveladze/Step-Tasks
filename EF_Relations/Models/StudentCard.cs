
namespace EF_Relations.Models;

public class StudentCard
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public DateTime IssuedDate { get; set; }
    
    public int StudentId  { get; set; }
    public Student? Student { get; set; }
}