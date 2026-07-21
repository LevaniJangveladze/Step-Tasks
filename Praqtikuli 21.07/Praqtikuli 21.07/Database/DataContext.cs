using System.Text.Json;
using Praqtikuli_21._07.Models;

namespace Praqtikuli_21._07.Database;

public sealed class DataContext
{
    private readonly string _path = "database.json";

    public List<Movie> Movies 
    { get; private set; } = new();
    
    private DataContext(){}

    private DataContext(List<Movie> movies)
    {
        Movies = movies;
    }

    public static DataContext Create()
    {
        if (File.Exists("database.json"))
        {
            string json = File.ReadAllText("database.json");
            DataContext? db = JsonSerializer.Deserialize<DataContext>(json);

            if (db == null) throw new Exception("Couldn't load database");

            return new DataContext(db.Movies);
        }
        else return new DataContext();
    }

    public void Save(DataContext db, string msg)
    {
        string json = JsonSerializer.Serialize(db);
        File.WriteAllText("database.json", json);
        Console.WriteLine(msg);
    }

}