using AUTH.Common;

namespace AUTH.Models
{
    internal class Product : Entity
    {
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public int CategoryId { get; private set; }

        private Product(string name, int stock, decimal price, int categoryId)
        {
            Name = name;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }

        public static Product Create(string name, int stock, decimal price, int categoryId)
        {
            if (name.Length < 3 || name.Length > 50)
                throw new Exception("product name must be greateer then 2 and lowwer then 50");

            if (stock < 0 || stock > 5000)
                throw new Exception("product stock must be greateer then 0 and lowwer then 5000");

            if (price < 1 || stock > 5000)
                throw new Exception("product price must be greateer then 0 and lowwer then 5000");

            if (stock < 1)
                throw new Exception("product category is required.");

            return new Product(name, stock, price, categoryId);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, stock: {Stock}, price: {Price}");
        }
        
        public void ChangeName(string name)
        {
            if (name.Length < 3 || name.Length > 50)
                throw new Exception("product name must be greateer then 2 and lowwer then 50");

            Name = name;
        }

        public void ChangeStock(int stock)
        {
            if (stock < 0 || stock > 5000)
                throw new Exception("product stock must be greateer then 0 and lowwer then 5000");

            Stock = stock;
        }

        public void ChangePrice(decimal price)
        {
            if (price < 1) throw new Exception("product price must be greateer then 0");

            Price = price;
        }
    }
}
