using AspNetCoreGeneratedDocument;
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


        [HttpGet]
        public IActionResult Index()
        {
            var skilItems = _appDbContext.SkillItems.AsNoTracking().ToList();
            return View(skilItems);
        }


        [HttpGet]
        public IActionResult CreateSkillItem()
        {
            var skillsList= _appDbContext.Skills.AsNoTracking().ToList();
            ViewBag.Skills = (from skill in skillsList
                              select new SelectListItem
            {
                Value= skill.Id.ToString(),
                Text= skill.Name,   
            }).ToList();
            return View();
        }



        [HttpPost]
        public IActionResult CreateSkillItem(SkillItem skillItems)
        {
            _appDbContext.SkillItems.Add(skillItems);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult UpdateSkillItem(int id)
        {
            var skillsList = _appDbContext.Skills.AsNoTracking().ToList();
            ViewBag.Skills = (from skill in skillsList
                              select new SelectListItem
                              {
                                  Value = skill.Id.ToString(),
                                  Text = skill.Name,
                              }).ToList();
            var skillItem = _appDbContext.SkillItems.Find(id);
            return View(skillItem);
        }



        [HttpPost]
        public IActionResult UpdateSkillItem(SkillItem skillItem)
        {
            _appDbContext.SkillItems.Update(skillItem);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult DeleteSkillItem(int id)
        {
            var skillItem = _appDbContext.SkillItems.Find(id);
            skillItem.IsActive= false;
            _appDbContext.SaveChanges();
            return View();
        }


    }
}
