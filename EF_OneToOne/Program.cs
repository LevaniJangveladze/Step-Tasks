using EF_OneToOne.Data;
using EF_OneToOne.Models;

using var context = new DataContext();

var product = new Product
{
    Name = "Laptop",
    Description = "Gaming laptop",
    Details = new ProductDetails
    {
        SerialNumber = "SN-12345",
        Category = "Electronics"
    }
};

context.Products.Add(product);
context.SaveChanges();

Console.WriteLine("Saved!");