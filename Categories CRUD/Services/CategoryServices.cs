using ConsoleApp12.Common;
using ConsoleApp12.Models;

namespace ConsoleApp12.Services
{
    internal sealed class CategoryServices
    {
        private Database _db;

        public CategoryServices(Database db) => _db = db;

        public void Create()
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();

            Console.Write("Enter category description: ");
            string desc = Console.ReadLine();

            Category category = Category.Create(name, desc);

            _db.Categories.Add(category);
            Result.Success("category created successfully.");
        }

        public void Delete()
        {
            Console.Write("Enter category ID: ");
            int id = int.Parse(Console.ReadLine());

            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) throw new Exception("category not found.");

            _db.Categories.Remove(category);
            Result.Success("category deleted successfully.");
        }

        public void Update()
        {
            Console.Write("Enter category ID: ");
            int id = int.Parse(Console.ReadLine());

            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) throw new Exception("category not found.");

            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                category.SetName(name);

            Console.Write("Enter category description: ");
            string desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc))
                category.SetDescription(desc);

            Result.Success("category updated successfully.");
        }

        public void Show()
        {
            _db.Categories.ForEach(c => c.ShowInfo());
        }

        public void Search()
        {
            Console.Write("Search: ");
            string search = Console.ReadLine().ToLower();

            List<Category> categories = _db.Categories
                .Where(c => c.Name.ToLower().Contains(search)).ToList();

            if (categories.Count == 0)
                throw new Exception($"category not found with search: {search}");

            categories.ForEach(c => c.ShowInfo());
        }

        public void AddProduct()
        {
            Console.Write("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine());
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) throw new Exception("category not found.");

            Console.Write("Enter product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Product? product = _db.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) throw new Exception("product not found.");

            product.SetCategoryId(category.Id);
            Result.Success("product added to category.");
        }

        public void RemoveProduct()
        {
            Console.Write("Enter product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Product? product = _db.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) throw new Exception("product not found.");

            product.RemoveCategoryId();
            Result.Success("product removed from category.");
        }

        public void ShowCategoriesWithProducts()
        {
            var result = _db.Categories.GroupJoin(
                _db.Products,
                c => c.Id,
                p => p.CategoryId,
                (c, p) => new { Category = c, Products = p }
            );

            foreach (var item in result)
            {
                Console.WriteLine($"Category: {item.Category.Name}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"   ID: {product.Id}, name: {product.Name}, price: {product.Price}");
                }
                Console.WriteLine("");
            }
        }
    }
}