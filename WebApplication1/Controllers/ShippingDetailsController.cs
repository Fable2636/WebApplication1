using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Infrastructure;
using WebApplication1.Models.ViewModel;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class ShippingDetailsController: Controller
    {
        private readonly WebApplication1Context _context;

        public ShippingDetailsController(WebApplication1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.ShippingDetails.ToListAsync());
        }

        public async Task<IActionResult> Add(jsonstring)
        {
            CartViewModel deserializedCartVM = JsonSerializer.FromJson<CartViewModel>(jsonstring);
            CartViewModel cartViewModel = await _context.CartViewModel.FindAsync(id);
            List<ShippingDetailsViewModel> shippingdetailviewmodel = HttpContext.Session.GetJson<List<ShippingDetailsViewModel>>("Shippingdetails") ?? new List<ShippingDetailsViewModel>();

            ShippingDetailsViewModel shippingdetailsitemviewmodel = shippingdetailviewmodel.Where(c => c.cartid == id).FirstOrDefault();

            HttpContext.Session.SetJson("Shipping Details", shippingdetailsitemviewmodel);
            return RedirectToAction("ShippingDetails", "Create");
        }
    }
}
