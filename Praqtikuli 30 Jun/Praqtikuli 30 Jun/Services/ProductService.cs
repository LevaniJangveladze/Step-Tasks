using Praqtikuli_30_Jun.Helpers;
using Praqtikuli_30_Jun.Models;

namespace Praqtikuli_30_Jun.Services;

public class ProductService
{
    private FileManager _fileManager = new FileManager();
    private List<Product> _products;

    public ProductService()
    {
        _products = _fileManager.Load();
    }

    public void Create()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        
        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Product newProduct = new Product()
        {
            Name = name,
            Price = price,
            Category = category
        };
        
        _products.Add(newProduct);
        _fileManager.Save(_products);
        Console.WriteLine("Product created successfully");
    }

    public void Show()
    {
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Name}, {product.Price}, {product.Category}");
        }
    }

    public void Delete()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Product? found = null;
        foreach (var product in _products)
        {
            if (product.Name == name)
            {
                found = product;
            }
        }

        if (found == null)
        {
            throw new Exception("Product not found");
        }
        _products.Remove(found);
        _fileManager.Save(_products);
        Console.WriteLine("Product deleted successfully");
    }

    public void Update()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        
        Product? found = null;
        foreach (var product in _products)
        {
            if (product.Name == name)
            {
                found = product;
            }
        }

        if (found == null)
        {
            throw new Exception("Product not found");
        }

       Console.Write("Enter new name: ");
       string newName = Console.ReadLine();
       if (!string.IsNullOrWhiteSpace(newName))
       {
           found.Name = newName;
       }
       
       Console.Write("Enter new category: ");
       string newCategory = Console.ReadLine();
       if (!string.IsNullOrWhiteSpace(newCategory))
       {
           found.Category = newCategory;
       }
       
       Console.Write("Enter new price: ");
       string priceInput = Console.ReadLine() ;
       if (!string.IsNullOrWhiteSpace(priceInput))
       {
           found.Price = decimal.Parse(priceInput);
       }
       
       _fileManager.Save(_products);
       Console.WriteLine("Product updated successfully");
    }
}