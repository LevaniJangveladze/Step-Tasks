namespace LibraryAPI.Dtos;

public class BookRequest
{
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public int AuthorId { get; set; }
}