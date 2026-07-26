using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDbContext _appDbContext;


        public EducationController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IActionResult> Index()
        {
            var educations = await _appDbContext.Educations.AsNoTracking().ToListAsync();
            if (educations is null)
                return NotFound();

            return View(educations);
        }


        [HttpGet]
        public async Task<IActionResult> CreateEducation()
        {
            
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateEducation(Education education)
        {
            if (!ModelState.IsValid)
                return View(education);
            
            try
            {
                _appDbContext.Educations.Add(education);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt sırasında hata oluştu.");
                return View(education);
            }
           
            
        }


        [HttpGet]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            var education = await _appDbContext.Educations.FindAsync(id);
            if (education is null)
                return NotFound();

            return View(education);
          
        }



        [HttpPost]
        public async Task<IActionResult> UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
                return View(education);
            try
            {
                _appDbContext.Educations.Update(education);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(education);
            }
           
           
        }

        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = _appDbContext.Educations.Find(id);
            if (education is null)
                return NotFound();

            try
            {
                _appDbContext.Educations.Remove(education);
                await  _appDbContext.SaveChangesAsync();
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
