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
        public IActionResult CreateSkill(Skill Skill)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateSkill()
        {
            return View();
        }

    }
}
