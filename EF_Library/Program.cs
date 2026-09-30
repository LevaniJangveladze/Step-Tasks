using EF_Library.Data;
using EF_Library.Models;
using EF_Library.Services;

using var context = new DataContext();
var service = new BookService(context);


service.AddBook(new Book
{
    Title = "Data and Reality",
    Author = "William Kent",
    PublishedYear = 1978,
    IsAvailable = true
});


service.UpdateBookTitle(1, "Vepkhistkaosani");

foreach (var book in service.GetAllBooks())
{
    Console.WriteLine($"{book.Id}: {book.Title} — {book.Author}");
}
