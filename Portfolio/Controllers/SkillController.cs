using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SkillController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var skills = await _appDbContext.Skills
                .AsNoTracking()
                .ToListAsync();

            return View(skills);
        }


        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            try
            {
                await _appDbContext.Skills.AddAsync(skill);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(skill);
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSkill(int id)
        {
            var skill = await _appDbContext.Skills.FindAsync(id);

            if (skill is null)
                return NotFound();

            return View(skill);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            try
            {
                _appDbContext.Skills.Update(skill);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(skill);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _appDbContext.Skills.FindAsync(id);

            if (skill is null)
                return NotFound();

            try
            {
                _appDbContext.Skills.Remove(skill);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(skill);
            }
        }
    }
}