using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmyazilim.Data;

[Area("Admin")]
[Authorize]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.ProductCount = await _context.Products.CountAsync();
        ViewBag.DemoCount = await _context.DemoRequests.CountAsync();
        ViewBag.TodayDemoCount = await _context.DemoRequests
            .CountAsync(x => x.CreatedDate.Date == DateTime.Today);

        ViewBag.RecentDemos = await _context.DemoRequests
            .OrderByDescending(x => x.CreatedDate)
            .Take(5)
            .ToListAsync();

        return View();
    }
}