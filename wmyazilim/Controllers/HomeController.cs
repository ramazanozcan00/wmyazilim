using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Gerekli
using wmyazilim.Data;                // Gerekli
using wmyazilim.Models;

namespace wmyazilim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Veritabaný baðlantýsý

        // Constructor'da veritabanýný alýyoruz (Dependency Injection)
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DemoRequest(DemoRequest model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                _context.DemoRequests.Add(model);
                await _context.SaveChangesAsync();

                // Baþarý mesajýný TempData ile gönderiyoruz
                TempData["DemoSuccess"] = "true";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            // Veritabanýndaki ürünleri asenkron olarak çekiyoruz
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // ... (Diðer kodlar)

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // ... (Privacy ve Error metodlarý aþaðýda kalabilir)

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // Referanslar Sayfasý
        public IActionResult References()
        {
            return View();
        }

        // Demo Talebi Sayfasý
        public IActionResult DemoRequest()
        {
            return View();
        }
    }
}