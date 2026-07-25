using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ServiceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _appDbContext.Services
                .AsNoTracking()
                .ToListAsync();

            return View(services);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            try
            {
                await _appDbContext.Services.AddAsync(service);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");
                return View(service);
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _appDbContext.Services.FindAsync(id);

            if (service is null)
                return NotFound();

            return View(service);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            try
            {
                _appDbContext.Services.Update(service);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                return View(service);
            }
        }



        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _appDbContext.Services.FindAsync(id);

            if (service is null)
                return NotFound();

            try
            {
                _appDbContext.Services.Remove(service);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(service);
            }
        }
    }
}

