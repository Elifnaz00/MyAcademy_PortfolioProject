using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System.Reflection;

namespace Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly AppDbContext _context;


        public IActionResult Index()
        {
            var experience = _context.Experiences.FirstOrDefault();
            return View(experience);
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }


        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            return View(experience);
        }



        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }



        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return View(experience);
        }


    }
}
