using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var about = _appDbContext.Abouts.FirstOrDefault();
            return View(about);
        }
    }
}
