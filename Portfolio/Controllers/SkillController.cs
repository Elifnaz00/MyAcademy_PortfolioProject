using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
