using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public IActionResult Index()
        {
            var skills = _appDbContext.Skills.AsNoTracking().ToList();
            return View(skills);
            
        }


        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            _appDbContext.Skills.Add(skill);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }


        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _appDbContext.Skills.Find(id);
            return View(skill);
        }



        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _appDbContext.Skills.Update(skill);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
           
        }

        [HttpPost]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _appDbContext.Skills.Find(id);
            _appDbContext.Skills.Remove(skill);
            _appDbContext.SaveChanges();
            return View();
        }


    }
}
