using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmyazilim.Data;
using wmyazilim.Models;

namespace wmyazilim.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu Controller'ın Admin alanına ait olduğunu belirtir
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ürünleri Listele
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Yeni Ürün Ekleme Sayfası (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Ürün Ekleme İşlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Ürün Silme İşlemi
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}