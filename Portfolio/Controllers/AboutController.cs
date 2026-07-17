using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            var about = _appDbContext.Abouts.FirstOrDefault();
            return View(about);
        }


        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _appDbContext.Abouts.Add(about);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about= _appDbContext.Abouts.Find(id);
            return View(about);
        }



        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _appDbContext.Abouts.Update(about);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult DeleteAbout(int id)
        {
            var about = _appDbContext.Abouts.Find(id);
            _appDbContext.Abouts.Remove(about);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
