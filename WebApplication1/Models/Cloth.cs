using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string size {  get; set; }
        public int Price { get; set; }
        [ValidateNever]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; } 
    }
}

