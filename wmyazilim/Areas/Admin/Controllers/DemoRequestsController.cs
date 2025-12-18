using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmyazilim.Data;
using wmyazilim.Models;

namespace wmyazilim.Areas.Admin.Controllers
{
    [Area("Admin")] // Admin Area tanımı
    public class DemoRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemoRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME
        public async Task<IActionResult> Index()
        {
            var requests = await _context.DemoRequests.OrderByDescending(x => x.CreatedDate).ToListAsync();
            return View(requests);
        }

        // 2. GÜNCELLEME (GET)
        public async Task<IActionResult> Edit(Guid id)
        {
            var request = await _context.DemoRequests.FindAsync(id);
            if (request == null) return NotFound();
            return View(request);
        }

        // 2. GÜNCELLEME (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DemoRequest model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // 3. SİLME
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = await _context.DemoRequests.FindAsync(id);
            if (request != null)
            {
                _context.DemoRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}