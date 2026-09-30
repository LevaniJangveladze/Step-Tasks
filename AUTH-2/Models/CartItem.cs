using AUTH.Common;

namespace AUTH.Models
{
    internal class CartItem : Entity
    {
        public int UserId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        private CartItem(int userId, int productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }

        public static CartItem Create(int userId, int productId, int quantity)
        {
            if (quantity < 1 || quantity > 20)
                throw new Exception("cart item quantity must be greater then 1 and lower then 20");

            return new CartItem(userId, productId, quantity);
        }
        
        public void ChangeQuantity(int quantity)
        {
            if (quantity < 1 || quantity > 20)
                throw new Exception("cart item quantity must be greater then 1 and lower then 20");

            Quantity = quantity;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, productId: {ProductId}, quantity: {Quantity}");
        }
    }
    
    
}
