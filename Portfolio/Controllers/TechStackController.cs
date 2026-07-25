using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TechStackController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TechStackController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var projectStacks = await _appDbContext.TechStacks
                .AsNoTracking()
                .ToListAsync();

            return View(projectStacks);
        }

        [HttpGet]
        public IActionResult CreateTechStack()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechStack(TechStack techStack)
        {
            if (!ModelState.IsValid)
            {
                return View(techStack);
            }

            try
            {
                await _appDbContext.TechStacks.AddAsync(techStack);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(techStack);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTechStack(int id)
        {
            var techStack = await _appDbContext.TechStacks.FindAsync(id);

            if (techStack is null)
                return NotFound();

            return View(techStack);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTechStack(TechStack techStack)
        {
            if (!ModelState.IsValid)
            {
                return View(techStack);
            }

            try
            {
                _appDbContext.TechStacks.Update(techStack);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(techStack);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTechStack(int id)
        {
            var techStack = await _appDbContext.TechStacks.FindAsync(id);

            if (techStack is null)
                return NotFound();

            try
            {
                _appDbContext.TechStacks.Remove(techStack);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(techStack);
            }
        }
    }
}