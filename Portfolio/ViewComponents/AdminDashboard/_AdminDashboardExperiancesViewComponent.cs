using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.AdminDashboard
{
    public class _AdminDashboardExperiancesViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public _AdminDashboardExperiancesViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IViewComponentResult Invoke()
        {
            TempData["ExperienceCount"] = _appDbContext.Experiences.Count();
            return View();
        }
    }
}
