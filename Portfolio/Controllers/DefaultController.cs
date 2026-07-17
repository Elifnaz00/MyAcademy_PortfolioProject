using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DefaultController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult SendMessage(UserMessage userMessage)
        {
            _appDbContext.UserMessages.Add(userMessage);    
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}
