namespace CarsAPI.Models;

public class Car
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}