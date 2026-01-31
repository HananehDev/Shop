namespace MySHop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public void AddItem(CartItem item)
        {
            if(CartItems.Exists(i=> i.Item.Id == item.Item.Id))
            {
                CartItems.Find(i => i.Item.Id == item.Item.Id).Quantity += 1; 
            }
            else
            {
                CartItems.Add(item);
            }
        }
        public void RemoveItem(int itemId)
        {
            var item = CartItems.SingleOrDefault(c => c.Item.Id == itemId);
            if(item?.Quantity <= 1)
            {
                CartItems.Remove(item);
            }
            else if(item != null) 
            {
                item.Quantity -= 1;
            }
        }

    }
}
