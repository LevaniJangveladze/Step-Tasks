using AUTH.Models;

namespace AUTH.Common
{
    internal class Database
    {
        public List<User> Users { get; private set; } = new List<User>();
        public List<Product> Products { get; private set; } = new List<Product>();
        public List<Category> Categories { get; private set; } = new List<Category>();
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();
    }
}
