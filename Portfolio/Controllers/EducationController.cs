using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateEducation(Education Education)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateEducation()
        {
            return View();
        }

    }
}
