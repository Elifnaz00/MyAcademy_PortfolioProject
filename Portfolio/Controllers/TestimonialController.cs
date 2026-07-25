using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TestimonialController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _appDbContext.Testimonials
                .AsNoTracking()
                .ToListAsync();

            return View(testimonials);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }

            try
            {
                await _appDbContext.Testimonials.AddAsync(testimonial);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(testimonial);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _appDbContext.Testimonials.FindAsync(id);

            if (testimonial is null)
                return NotFound();

            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                return View(testimonial);
            }

            try
            {
                _appDbContext.Testimonials.Update(testimonial);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(testimonial);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _appDbContext.Testimonials.FindAsync(id);

            if (testimonial is null)
                return NotFound();

            try
            {
                _appDbContext.Testimonials.Remove(testimonial);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(testimonial);
            }
        }
    }
}