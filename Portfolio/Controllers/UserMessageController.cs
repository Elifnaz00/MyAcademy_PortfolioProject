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

        public async Task<IActionResult> AllMessages()
        {
            var readMessagesList = await _appDbContext.UserMessages
                .AsNoTracking()
                .ToListAsync();

            return View(readMessagesList);
        }

        public async Task<IActionResult> ReadMessages()
        {
            var readMessagesList = await _appDbContext.UserMessages
                .AsNoTracking()
                .Where(x => x.IsRead)
                .ToListAsync();

            return View(readMessagesList);
        }

        [HttpGet]
        public async Task<IActionResult> UnReadMessages()
        {
            var unReadMessagesList = await _appDbContext.UserMessages
                .AsNoTracking()
                .Where(x => !x.IsRead)
                .ToListAsync();

            return View(unReadMessagesList);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var message = await _appDbContext.UserMessages.FindAsync(id);

            if (message is null)
                return NotFound();

            try
            {
                message.IsRead = true;
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = await _appDbContext.UserMessages.FindAsync(id);

            if (message is null)
                return NotFound();

            try
            {
                if (!message.IsRead)
                {
                    message.IsRead = true;
                    await _appDbContext.SaveChangesAsync();
                }

                return View(message);
            }
            catch
            {
                ModelState.AddModelError("", "Mesaj görüntülenirken bir hata oluştu.");
                return View(message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMessages(int id)
        {
            var message = await _appDbContext.UserMessages.FindAsync(id);

            if (message is null)
                return NotFound();

            try
            {
                _appDbContext.UserMessages.Remove(message);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(AllMessages));
            }
            catch
            {
                ModelState.AddModelError("", "Silme sırasında hata oluştu.");
                return View(message);
            }
        }
    }
}