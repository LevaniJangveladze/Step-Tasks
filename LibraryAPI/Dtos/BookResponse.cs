namespace LibraryAPI.Dtos;

public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string AuthorName { get; set; } = string.Empty;
}