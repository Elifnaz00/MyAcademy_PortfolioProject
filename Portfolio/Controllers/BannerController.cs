using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var banner= _context.Banners.FirstOrDefault();
            return View(banner);
        }


        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var banner= _context.Banners.Find(id);
            return View(banner);
        }



        [HttpPost]
        public IActionResult UpdateBanner(Banner banner)
        {
            _context.Banners.Update(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
