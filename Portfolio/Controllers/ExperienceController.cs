using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System.Reflection;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _context;


        public ExperienceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var experience = await _context.Experiences.AsNoTracking().ToListAsync();

            if (experience is null)
                return NotFound();

            return View(experience);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            try
            {
                await _context.Experiences.AddAsync(experience);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(experience);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);

            if (experience is null)
                return NotFound();

            return View(experience);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            try
            {
                _context.Experiences.Update(experience);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(experience);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);

            if (experience is null)
                return NotFound();

            try
            {
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(experience);
            }
        }

    }
}
