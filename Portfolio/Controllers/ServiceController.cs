using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public IActionResult Index()
        {
            var services = _appDbContext.Services.AsNoTracking().ToList();
            return View(services);
            
        }


        [HttpGet]
        public IActionResult CreateService()
        {

            return View();
        }



        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _appDbContext.Services.Add(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
           
        }


        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _appDbContext.Services.Find(id);
            return View(service);
        }



        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _appDbContext.Services.Update(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteService(int id)
        {
            var service = _appDbContext.Services.Find(id);
            _appDbContext.Services.Remove(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
