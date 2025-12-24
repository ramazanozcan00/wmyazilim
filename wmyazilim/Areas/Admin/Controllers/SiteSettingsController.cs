using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wmyazilim.Data;
using wmyazilim.Models;

namespace wmyazilim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiteSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Genel Görünüm (Menü, Footer ve Hero Ayarları)
        public async Task<IActionResult> Index()
        {
            var viewModel = new SiteSettingsViewModel
            {
                MenuItems = await _context.HeaderMenuItems.OrderBy(x => x.Order).ToListAsync(),
                FooterSetting = await _context.FooterSettings.FirstOrDefaultAsync() ?? new FooterSetting(),
                HeroSetting = await _context.HeroSettings.FirstOrDefaultAsync() ?? new HeroSetting()
            };
            return View(viewModel);
        }

        // --- MENÜ İŞLEMLERİ ---

        [HttpPost]
        public async Task<IActionResult> CreateMenu(HeaderMenuItem item)
        {
            if (ModelState.IsValid)
            {
                _context.HeaderMenuItems.Add(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var item = await _context.HeaderMenuItems.FindAsync(id);
            if (item != null)
            {
                _context.HeaderMenuItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // --- FOOTER İŞLEMLERİ ---

        [HttpPost]
        public async Task<IActionResult> UpdateFooter(FooterSetting setting)
        {
            var existing = await _context.FooterSettings.FirstOrDefaultAsync();
            if (existing == null)
            {
                _context.FooterSettings.Add(setting);
            }
            else
            {
                existing.Description = setting.Description;
                existing.Email = setting.Email;
                existing.PhoneNumber = setting.PhoneNumber;
                existing.Address = setting.Address;
                existing.CopyrightText = setting.CopyrightText;
                _context.Update(existing);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // --- HERO (ANASAYFA) İŞLEMLERİ ---

        // UpdateHero metodunu bul ve şu şekilde güncelle:
        [HttpPost]
        public async Task<IActionResult> UpdateHero(HeroSetting setting)
        {
            var existing = await _context.HeroSettings.FirstOrDefaultAsync();
            if (existing == null)
            {
                _context.HeroSettings.Add(setting);
            }
            else
            {
                // Rozet Ayarları - YENİ
                existing.BadgeText = setting.BadgeText;
                existing.BadgeIcon = setting.BadgeIcon;

                // Mevcut Ayarlar
                existing.MainTitle = setting.MainTitle;
                existing.SubDescription = setting.SubDescription;
                existing.HeroImageUrl = setting.HeroImageUrl;
                existing.Button1Text = setting.Button1Text;
                existing.Button1Url = setting.Button1Url;
                existing.Button2Text = setting.Button2Text;
                existing.Button2Url = setting.Button2Url;

                _context.Update(existing);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

    // View İçin Yardımcı Model (HeroSetting sınıfı BURADA DEĞİL, Models klasöründe olmalı)
    public class SiteSettingsViewModel
    {
        public List<HeaderMenuItem> MenuItems { get; set; }
        public FooterSetting FooterSetting { get; set; }
        public HeroSetting HeroSetting { get; set; }
    }
}