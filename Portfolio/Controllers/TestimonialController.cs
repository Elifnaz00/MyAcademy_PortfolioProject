using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateTestimonial()
        {
            return View();
        }



    }
}
