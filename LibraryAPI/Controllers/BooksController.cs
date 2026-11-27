using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly DataContext _db;

    public BooksController(DataContext db) => _db = db;

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _db.Books
            .Include(b => b.Author)
            .Select(b => new BookResponse { Id = b.Id, Title = b.Title, Year = b.Year, AuthorName = b.Author!.Name })
            .ToList();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var b = _db.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
        if (b == null) return NotFound();

        return Ok(new BookResponse { Id = b.Id, Title = b.Title, Year = b.Year, AuthorName = b.Author!.Name });
    }

    [HttpPost]
    public IActionResult Create(BookRequest req)
    {
        if (_db.Authors.Find(req.AuthorId) == null) return BadRequest("Author not found");

        var book = new Book { Title = req.Title, Year = req.Year, AuthorId = req.AuthorId };

        _db.Books.Add(book);
        _db.SaveChanges();

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BookRequest req)
    {
        var book = _db.Books.Find(id);
        if (book == null) return NotFound();

        book.Title = req.Title;
        book.Year = req.Year;
        book.AuthorId = req.AuthorId;
        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _db.Books.Find(id);
        if (book == null) return NotFound();

        _db.Books.Remove(book);
        _db.SaveChanges();

        return NoContent();
    }
}