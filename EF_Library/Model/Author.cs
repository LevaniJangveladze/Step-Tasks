namespace EF_Library.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string Phone { get; set; }  = string.Empty;
}