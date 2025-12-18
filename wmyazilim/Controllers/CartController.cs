using Microsoft.AspNetCore.Mvc;
using wmyazilim.Data;
using wmyazilim.Helpers;
using wmyazilim.Models;

namespace wmyazilim.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Sepeti Görüntüle
        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            // Toplam tutarı View'e taşıyalım
            ViewBag.Total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View(cart);
        }

        // Sepete Ekle
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            var cart = GetCartFromSession();
            var existingItem = cart.FirstOrDefault(x => x.Product.Id == id);

            if (existingItem != null)
            {
                existingItem.Quantity++; // Zaten varsa adedini artır
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            SaveCartToSession(cart);

            // Kullanıcıyı sepet sayfasına yönlendir (veya geldiği yere)
            return RedirectToAction("Index");
        }

        // Sepetten Sil
        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item != null)
            {
                cart.Remove(item);
                SaveCartToSession(cart);
            }
            return RedirectToAction("Index");
        }

        // --- Yardımcı Metodlar ---
        private List<CartItem> GetCartFromSession()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("MyCart");
            return cart ?? new List<CartItem>();
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            HttpContext.Session.Set("MyCart", cart);
        }
    }
}