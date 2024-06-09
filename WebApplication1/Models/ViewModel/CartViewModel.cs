namespace WebApplication1.Models.ViewModel
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
