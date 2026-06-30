using System.Text.Json;
using Praqtikuli_30_Jun.Models;

namespace Praqtikuli_30_Jun.Helpers;

public class FileManager
{
    private const string FilePath = "Products.json";

    public void Save(List<Product> products)
    {
        string json = JsonSerializer.Serialize(products);
        File.WriteAllText(FilePath, json);
    }

    public List<Product> Load()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Product>();
        }
        
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Product>>(json);
    }
    
}