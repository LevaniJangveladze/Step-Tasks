using Praqtikuli_21._07.Common;

namespace Praqtikuli_21._07.Models;

public sealed class Movie : Entity
{
    public string Title { get; private set; }
    public string Genre { get; private set;  }
    public int Year { get; private set; }
    public int Rating { get; private set; }

    private Movie(string title, string genre, int year, int rating)
    {
        Title = title;
        Genre = genre;
        Year = year;
        Rating = rating;
    }


    public static Movie Create(string title, string genre, int year, int rating)
    {
        Guards.AgainstInvalidLength(1, 100, title);
        Guards.AgainstInvalidLength(3, 30, genre);
        Guards.AgainstOutOfRange(1888, DateTime.UtcNow.Year, year);
        Guards.AgainstOutOfRange(0, 10, rating);

        return new Movie(title, genre, year, rating);
    }

    public void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}, title: {Title}, genre: {Genre}, year: {Year}, rating: {Rating}");
    }
    
}