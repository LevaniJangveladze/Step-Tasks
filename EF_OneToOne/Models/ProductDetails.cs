namespace EF_OneToOne.Models;

public class ProductDetails
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public string? Category { get; set; }
    
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}