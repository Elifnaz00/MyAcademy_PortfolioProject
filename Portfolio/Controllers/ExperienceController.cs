using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        

             public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateExperience(Experience Experience)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateExperience()
        {
            return View();
        }


    }
}
