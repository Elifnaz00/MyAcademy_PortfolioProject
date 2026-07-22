using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class BannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateBanner(Banner Banner)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateBanner()
        {
            return View();
        }

    }
}
