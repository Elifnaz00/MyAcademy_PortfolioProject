using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public IActionResult Index()
        {
            var education = _appDbContext.Educations.FirstOrDefault();
            return View(education);
        }


        [HttpGet]
        public IActionResult CreateEducation()
        {
            
            return View();
        }



        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            _appDbContext.Educations.Add(education);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }


        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var Education = _appDbContext.Educations.Find(id);
            return View(Education);
          
        }



        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            _appDbContext.Educations.Update(education);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public IActionResult DeleteEducation(int id)
        {
            var education = _appDbContext.Educations.Find(id);
            _appDbContext.Educations.Remove(education);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
