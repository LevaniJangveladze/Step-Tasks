using ConsoleApp12.Common;

namespace ConsoleApp12.Models
{
    internal sealed class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int? CategoryId { get; private set; }

        private Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static Product Create(string name, decimal price)
        {
            ValidateName(name);
            ValidatePrice(price);
            return new Product(name, price);
        }

        public void SetCategoryId(int categoryId) => CategoryId = categoryId;
        public void RemoveCategoryId() => CategoryId = null;

        public void SetName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        public void SetPrice(decimal price)
        {
            ValidatePrice(price);
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Name}, price: {Price}, categoryId: {CategoryId}");
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("product name is required");
        }

        private static void ValidatePrice(decimal price)
        {
            if (price <= 0)
                throw new Exception("product price must be greater then 0");
        }
    }
}