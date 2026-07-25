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

        public ContactInfoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync();
            if(contactInfo is null)
                return NotFound();

            return View(contactInfo);
        }


        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(ContactInfo ContactInfo)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                _context.ContactInfos.Add(ContactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(ContactInfo);
            }
          
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContactInfo(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo is null)
                return NotFound();

            return View(contactInfo);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                _context.ContactInfos.Update(contactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(contactInfo);
            }
           
        }



        [HttpGet]
        public async Task<IActionResult> DeleteContactInfo(int id) {
            var contactInfo= _context.ContactInfos.Find();
            if (contactInfo is null)
                return NotFound();

            try
            {
                _context.ContactInfos.Remove(contactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View();
            }

        }

    }
}
