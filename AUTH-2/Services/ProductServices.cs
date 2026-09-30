using AUTH.Common;
using AUTH.Models;

namespace AUTH.Services
{
    internal class ProductServices
    {
        private Database _db;
        public ProductServices(Database db) => _db = db;

        public void Create()
        {
            foreach (var c in _db.Categories) c.ShowInfo();

            Console.Write("Enter category id: ");
            int categoryId = int.Parse(Console.ReadLine());

            Category? category = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) throw new Exception("category not found");

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter stock: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Product product = Product.Create(name, stock, price, categoryId);

            _db.Products.Add(product);
            Result.Success("product created successfully.");
        }

        public void Delete()
        {
            Show();

            Console.Write("Enter product id: ");
            int id = int.Parse(Console.ReadLine());

            Product? product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("product not found");

            _db.Products.Remove(product);
            Result.Success("product deleted successfully.");
        }

        public void Update()
        {
            Show();

            Console.Write("Enter product id: ");
            int id = int.Parse(Console.ReadLine());

            Product? product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) throw new Exception("product not found");

            Console.Write("Enter new name: ");
            product.ChangeName(Console.ReadLine());

            Console.Write("Enter new stock: ");
            product.ChangeStock(int.Parse(Console.ReadLine()));

            Console.Write("Enter new price: ");
            product.ChangePrice(decimal.Parse(Console.ReadLine()));

            Result.Success("product updated successfully.");
        }

        public void Show()
        {
            foreach (var product in _db.Products) product.ShowInfo();
        }

        public void Search()
        {
            Console.Write("Enter search text: ");
            string text = Console.ReadLine();

            var products = _db.Products.Where(p => p.Name.ToLower().Contains(text.ToLower()));

            foreach (var product in products) product.ShowInfo();
        }

        public void FilterByPrice()
        {
            Console.Write("Enter min price: ");
            decimal min = decimal.Parse(Console.ReadLine());

            Console.Write("Enter max price: ");
            decimal max = decimal.Parse(Console.ReadLine());

            var products = _db.Products.Where(p => p.Price >= min && p.Price <= max);

            foreach (var product in products) product.ShowInfo();
        }

        public void FilterByCategoryId()
        {
            foreach (var c in _db.Categories) c.ShowInfo();

            Console.Write("Enter category id: ");
            int categoryId = int.Parse(Console.ReadLine());

            var products = _db.Products.Where(p => p.CategoryId == categoryId);

            foreach (var product in products) product.ShowInfo();
        }
    }
}