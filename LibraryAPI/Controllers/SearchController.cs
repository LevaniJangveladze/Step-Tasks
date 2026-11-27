using LibraryAPI.Data;
using LibraryAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly DataContext _db;

    public SearchController(DataContext db) => _db = db;

    [HttpGet("by-author/{authorId}")]
    public IActionResult BooksByAuthor(int authorId)
    {
        var books = _db.Books
            .Include(b => b.Author)
            .Where(b => b.AuthorId == authorId)
            .Select(b => new BookResponse { Id = b.Id, Title = b.Title, Year = b.Year, AuthorName = b.Author!.Name })
            .ToList();

        return Ok(books);
    }

    [HttpGet("by-title")]
    public IActionResult BooksByTitle(string text)
    {
        var books = _db.Books
            .Include(b => b.Author)
            .Where(b => b.Title.Contains(text))
            .Select(b => new BookResponse { Id = b.Id, Title = b.Title, Year = b.Year, AuthorName = b.Author!.Name })
            .ToList();

        return Ok(books);
    }
}