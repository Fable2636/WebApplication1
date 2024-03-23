using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly WebApplication1Context _context;
        


        public ClothesController(WebApplication1Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Clothes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cloth.ToListAsync());
        }


        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Item,QuantityXS,QuantityS,QuantityL,QuantityXL,QuantityXXL,Price,ImageFile")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                Console.WriteLine(wwwRootPath);
                string fileName = Path.GetFileNameWithoutExtension(cloth.ImageFile.FileName);
                string extension = Path.GetExtension(cloth.ImageFile.FileName);
                cloth.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await cloth.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(cloth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cloth);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth.FindAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }
            return View(cloth);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Item,QuantityXS,QuantityS,QuantityL,QuantityXL,QuantityXXL,Price")] Cloth cloth)
        {
            if (id != cloth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothExists(cloth.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cloth);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloth = await _context.Cloth.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", cloth.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            if (cloth != null)
            {
                _context.Cloth.Remove(cloth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothExists(int id)
        {
            return _context.Cloth.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddCheckout(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cloth = await _context.Cloth
                    .FirstOrDefaultAsync(m => m.Id == id);
                var shippingdetails = cloth;
                if (shippingdetails == null)
                {
                    return NotFound();
                }

                return View(shippingdetails);
            }
            else 
            {
                return NotFound();
            }
                
        }
        public async Task<IActionResult> Checkout(int? id)
        {
            var cloth = await _context.Cloth.FindAsync(id);
            return View();
        }

        public async Task<IActionResult> AdminCheckout()
        {
            return View(await _context.ShippingDetails.ToListAsync());
        }

        public async Task<IActionResult> AddCheckout1([Bind("Id,Name,Line1,Line2,Line3,City,Country,GiftWrap,size,itemname")] ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(shippingDetails);
        }
    }
}
