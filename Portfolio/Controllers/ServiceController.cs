using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateService(Service Service)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateService()
        {
            return View();
        }

    }
}
