using AUTH.Common;
using AUTH.Models;

namespace AUTH.Services
{
    internal class CartServices
    {
        private Database _db;
        public CartServices(Database db) => _db = db;

        public void Create()
        {
            foreach (var p in _db.Products) p.ShowInfo();

            Console.Write("Enter product id: ");
            int productId = int.Parse(Console.ReadLine());

            Product? product = _db.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) throw new Exception("product not found");

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity > product.Stock) throw new Exception("not enough stock");

            int userId = Auth.GetUser().Id;

            CartItem item = CartItem.Create(userId, productId, quantity);

            _db.CartItems.Add(item);
            Result.Success("added to cart successfully.");
        }

        public void Delete()
        {
            Show();

            Console.Write("Enter cart item id: ");
            int id = int.Parse(Console.ReadLine());

            int userId = Auth.GetUser().Id;

            CartItem? item = _db.CartItems.FirstOrDefault(i => i.Id == id && i.UserId == userId);
            if (item == null) throw new Exception("cart item not found");

            _db.CartItems.Remove(item);
            Result.Success("removed from cart successfully.");
        }

        public void Update()
        {
            Show();

            Console.Write("Enter cart item id: ");
            int id = int.Parse(Console.ReadLine());

            int userId = Auth.GetUser().Id;

            CartItem? item = _db.CartItems.FirstOrDefault(i => i.Id == id && i.UserId == userId);
            if (item == null) throw new Exception("cart item not found");

            Console.Write("Enter new quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            item.ChangeQuantity(quantity);
            Result.Success("cart item updated successfully.");
        }

        public void Show()
        {
            int userId = Auth.GetUser().Id;

            var items = _db.CartItems.Where(i => i.UserId == userId);

            foreach (var item in items)
            {
                Product? product = _db.Products.FirstOrDefault(p => p.Id == item.ProductId);

                Console.WriteLine($"ID: {item.Id}, product: {product?.Name}, quantity: {item.Quantity}, total: {product?.Price * item.Quantity}");
            }
        }
    }
}