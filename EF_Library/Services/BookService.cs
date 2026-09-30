using EF_Library.Data;
using EF_Library.Models;

namespace EF_Library.Services;

public class BookService
{
    private readonly DataContext _context;
    
    public BookService(DataContext context)
    {
        _context = context;
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }
    
    public void UpdateBookTitle(int id, string newTitle)
    {
        var book = _context.Books.Find(id);
        if (book == null) return;

        book.Title = newTitle;
        _context.SaveChanges();
    }
    
    public void DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return;

        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}