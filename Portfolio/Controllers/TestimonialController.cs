using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _appDbContext;


        public IActionResult Index()
        {
            var testimonials = _appDbContext.Testimonials.AsNoTracking().ToList();
            return View(testimonials);
           
        }


        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _appDbContext.Testimonials.Add(testimonial);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

            
        }


        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = _appDbContext.Testimonials.Find(id);
            return View(testimonial);
        }



        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _appDbContext.Testimonials.Update(testimonial);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial= _appDbContext.Testimonials.Find(id);
            _appDbContext.Testimonials.Remove(testimonial);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
