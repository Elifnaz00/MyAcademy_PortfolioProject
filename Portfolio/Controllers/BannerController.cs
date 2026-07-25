using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var banner= await _context.Banners.FirstOrDefaultAsync();
            if(banner is null)
                return NotFound();

            return View(banner);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var banner= await _context.Banners.FindAsync(id);
            if(banner is null)
                return NotFound();

            return View(banner);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateBanner(Banner banner)
        {
            if (!ModelState.IsValid) { 
                return View(banner);
            }

            try
            {
                _context.Banners.Update(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt güncellenirken bir hata oluştu.");
                return View(banner);
            }
           
        }

    }
}
