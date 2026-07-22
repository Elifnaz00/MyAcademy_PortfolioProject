using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.AdminDashboard
{
    public class _AdminDashboardProjectsViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public _AdminDashboardProjectsViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            TempData["ProjectCount"] = _appDbContext.Projects.Count();
            return View();
        }
    }
}
