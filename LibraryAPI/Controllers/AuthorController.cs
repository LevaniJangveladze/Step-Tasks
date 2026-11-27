using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly DataContext _db;
    
    public AuthorController(DataContext db) =>_db = db;

    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = _db.Authors.Select(a => new AuthorResponse{ Id = a.Id, Name = a.Name, Country = a.Country})
            .ToList();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var a = _db.Authors.Find(id);
        if (a == null) return  NotFound();
        return Ok(new AuthorResponse{ Id = a.Id, Name = a.Name, Country = a.Country});
    }

    [HttpPost]
    public IActionResult Create(AuthorRequest req)
    {
        var author = new Author { Name = req.Name, Country = req.Country };
        
        _db.Authors.Add(author);
        _db.SaveChanges();

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, AuthorRequest req)
    {
        var author = _db.Authors.Find(id);
        if (author == null) return NotFound();
        
        author.Name = req.Name;
        author.Country = req.Country;
        _db.SaveChanges();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var author = _db.Authors.Find(id);
        if (author == null) return NotFound();

        _db.Authors.Remove(author);
        _db.SaveChanges();

        return NoContent();
    }
    
    
}