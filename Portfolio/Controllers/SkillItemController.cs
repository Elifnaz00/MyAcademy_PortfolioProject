using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SkillItemController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SkillItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> CreateSkillItem()
        {
            var skillsList = await _appDbContext.Skills
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Skills = (from skill in skillsList
                              select new SelectListItem
                              {
                                  Value = skill.Id.ToString(),
                                  Text = skill.Name,
                              }).ToList();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSkillItem(SkillItem skillItem)
        {
            if (!ModelState.IsValid)
            {
                var skillsList = await _appDbContext.Skills
                    .AsNoTracking()
                    .ToListAsync();

                ViewBag.Skills = (from skill in skillsList
                                  select new SelectListItem
                                  {
                                      Value = skill.Id.ToString(),
                                      Text = skill.Name,
                                  }).ToList();

                return View(skillItem);
            }

            try
            {
                skillItem.IsActive = true;
                await _appDbContext.SkillItems.AddAsync(skillItem);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index","Skill");
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");

                var skillsList = await _appDbContext.Skills
                    .AsNoTracking()
                    .ToListAsync();

                ViewBag.Skills = (from skill in skillsList
                                  select new SelectListItem
                                  {
                                      Value = skill.Id.ToString(),
                                      Text = skill.Name,
                                  }).ToList();

                return View(skillItem);
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSkillItem(int id)
        {
            var skillsList = await _appDbContext.Skills
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Skills = (from skill in skillsList
                              select new SelectListItem
                              {
                                  Value = skill.Id.ToString(),
                                  Text = skill.Name,
                              }).ToList();

            var skillItem = await _appDbContext.SkillItems.FindAsync(id);

            if (skillItem is null)
                return NotFound();

            return View(skillItem);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSkillItem(SkillItem skillItem)
        {
            if (!ModelState.IsValid)
            {
                var skillsList = await _appDbContext.Skills
                    .AsNoTracking()
                    .ToListAsync();

                ViewBag.Skills = (from skill in skillsList
                                  select new SelectListItem
                                  {
                                      Value = skill.Id.ToString(),
                                      Text = skill.Name,
                                  }).ToList();

                return View(skillItem);
            }

            try
            {
                _appDbContext.SkillItems.Update(skillItem);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Skill");
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");

                var skillsList = await _appDbContext.Skills
                    .AsNoTracking()
                    .ToListAsync();

                ViewBag.Skills = (from skill in skillsList
                                  select new SelectListItem
                                  {
                                      Value = skill.Id.ToString(),
                                      Text = skill.Name,
                                  }).ToList();

                return View(skillItem);
            }
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSkillItem(int id)
        {
            var skillItem = await _appDbContext.SkillItems.FindAsync(id);

            if (skillItem is null)
                return NotFound();

            try
            {
                skillItem.IsActive = false;
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Skill");
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(skillItem);
            }
        }
    }
}