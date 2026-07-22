using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public UserMessageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult ReadMessages()
        {
            var readMessagesList=_appDbContext.UserMessages.Where(x => x.IsRead == true).ToList();
            return View(readMessagesList);
        }




        [HttpGet]
        public IActionResult UnReadMessages()
        {
            var unReadMessagesList = _appDbContext.UserMessages.Where(x => x.IsRead == false).ToList();
            return View(unReadMessagesList);
        }



        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            var message = _appDbContext.UserMessages.Find(id);
            message.IsRead = true;
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}
