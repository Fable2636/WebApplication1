using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ShippingDetails
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        [Display(Name = "Первый адрес")]
        public string Line1 { get; set; }

        [Display(Name = "Второй адрес")]
        public string Line2 { get; set; }

        [Display(Name = "Третий адрес")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }

        public string size { get; set; }
        [ValidateNever]
        public string itemname { get; set; }
        public int quantity { get; set; }

        public ShippingDetails()
        {
        }

        public ShippingDetails(CartItem cartItem)
        {
            CartId = cartItem.Id;
            itemname = cartItem.ProductName;
            size = cartItem.size;
            quantity = cartItem.Quantity;
        }
    }
}
