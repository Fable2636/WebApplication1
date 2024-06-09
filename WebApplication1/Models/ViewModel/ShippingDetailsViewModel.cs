namespace WebApplication1.Models.ViewModel
{
    public class ShippingDetailsViewModel
    {
        public int Id { get; set; }
        public int cartid { get; set; }
        public List<ShippingDetails> CartItems { get; set; }
    }
}
