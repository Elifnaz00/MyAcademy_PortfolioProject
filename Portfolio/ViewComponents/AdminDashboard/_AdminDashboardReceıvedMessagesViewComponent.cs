using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.AdminDashboard
{
    public class _AdminDashboardReceıvedMessagesViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public _AdminDashboardReceıvedMessagesViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IViewComponentResult Invoke()
        {
            TempData["MessageCount"] =  _appDbContext.UserMessages.Count();
            return View();
        }
    }
}
