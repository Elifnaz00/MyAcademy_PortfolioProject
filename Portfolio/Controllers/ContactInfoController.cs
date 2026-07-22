using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ContactInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo ContactInfo)
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpdateContactInfo(int id)
        {
            return View();
        }



        [HttpGet]
        public IActionResult UpdateContactInfo()
        {
            return View();
        }

    }
}
