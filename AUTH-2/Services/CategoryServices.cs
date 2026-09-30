using AUTH.Common;
using AUTH.Models;

namespace AUTH.Services
{
    internal class CategoryServices
    {
        private Database _db;
        public CategoryServices(Database db) => _db = db;

        public void Create()
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            
            Category category = Category.Create(name);
            
            _db.Categories.Add(category);
            Result.Success("Category created successfully");
        }

        public void Delete()
        {
            Show();
            Console.Write("Enter category id: ");
            int id =  int.Parse(Console.ReadLine());
            
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            
            if(category == null) throw new Exception("category not found");
            
            _db.Categories.Remove(category);
            Result.Success("Category deleted successfully");
            
        }

        public void Update()
        {   
            Show();
            Console.Write("Enter category id: ");
            int id = int.Parse(Console.ReadLine());
            
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null) throw new Exception("category not found");
            
            Console.Write("Enter new name: ");
            string name = Console.ReadLine();

            category.ChangeName(name);
            Result.Success("category updated successfully.");

        }

        public void Show()
        {
            foreach (var category in _db.Categories)
            {
                category.ShowInfo();
            }
            
        }

        public void ShowWithProducts()
        {
            foreach (var category in _db.Categories)
            {
                category.ShowInfo();

                var products = _db.Products.Where(p => p.CategoryId == category.Id);

                foreach (var product in products)
                {
                    Console.Write("  ");
                    product.ShowInfo();
                }
            }
        }
    }
}
