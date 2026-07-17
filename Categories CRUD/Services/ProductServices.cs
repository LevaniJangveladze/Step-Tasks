using ConsoleApp12.Common;
using ConsoleApp12.Models;

namespace ConsoleApp12.Services
{
    internal sealed class ProductServices
    {
        private Database _db;

        public ProductServices(Database db) => _db = db;

        public void Create()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Product product = Product.Create(name, price);

            _db.Products.Add(product);
            Result.Success("product created successfully.");
        }

        public void Delete()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product? product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("product not found.");

            _db.Products.Remove(product);
            Result.Success("product deleted successfully.");
        }

        public void Update()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product? product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("product not found.");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                product.SetName(name);

            Console.Write("Enter product price: ");
            string price = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(price))
                product.SetPrice(decimal.Parse(price));

            Result.Success("product updated successfully.");
        }

        public void Show()
        {
            _db.Products.ForEach(p => p.ShowInfo());
        }

        public void Search()
        {
            Console.Write("Search: ");
            string search = Console.ReadLine().ToLower();

            List<Product> products = _db.Products
                .Where(p => p.Name.ToLower().Contains(search)).ToList();

            if (products.Count == 0)
                throw new Exception($"product not found with search: {search}");

            products.ForEach(p => p.ShowInfo());
        }
    }
}