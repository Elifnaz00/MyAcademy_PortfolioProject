using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System.Reflection;

namespace Portfolio.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly AppDbContext _context;

        public IActionResult Index()
        {
            var contactInfo = _context.ContactInfos.FirstOrDefault();
            return View(contactInfo);
        }


        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo ContactInfo)
        {
            _context.ContactInfos.Add(ContactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateContactInfo(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            return View(contactInfo);
        }



        [HttpPost]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Update(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteContactInfo(int id) {
            var contactInfo= _context.ContactInfos.Find();
            _context.ContactInfos.Remove(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
