using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult AllMessages()
        {
            var readMessagesList = _appDbContext.UserMessages.AsNoTracking().ToList();
            return View(readMessagesList);
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


        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = await _appDbContext.UserMessages.FindAsync(id);
            if (message is null)
                return NotFound();
           
            if (!message.IsRead)
            {
                message.IsRead = true;
                await _appDbContext.SaveChangesAsync();
            }
        
            return View(message);
        }


        [HttpGet]
        public IActionResult DeleteMessages(int id)
        {
            var unReadMessagesList = _appDbContext.UserMessages.Find(id);
            _appDbContext.UserMessages.Remove(unReadMessagesList);  
            _appDbContext.SaveChanges();
           
            return View(unReadMessagesList);
        }


    }
}
