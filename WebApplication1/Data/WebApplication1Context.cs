using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Cloth> Cloth { get; set; } = default!;
        public DbSet<WebApplication1.Models.ShippingDetails> ShippingDetails { get; set; } = default!;
        public DbSet<WebApplication1.Models.CartItem> Cart { get; set; } = default!;
        public DbSet<WebApplication1.Models.ViewModel.CartViewModel> CartViewModel { get; set; } = default!;
    }
}
