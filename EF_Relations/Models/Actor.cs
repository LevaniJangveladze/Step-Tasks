namespace EF_Relations.Models;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List <Movie> Movies { get; set; } = new List<Movie>();
}