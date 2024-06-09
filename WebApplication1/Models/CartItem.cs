using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CartItem 
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }

        public CartItem()
        {
        }

        public CartItem(Cloth cloth)
        {
            ProductId = cloth.Id;
            ProductName = cloth.Name;
            size = cloth.size;
            Price = cloth.Price;
            Quantity = 1;
        }
    }
}
