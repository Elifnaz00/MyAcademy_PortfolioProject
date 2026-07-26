using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.AdminLayout
{
    public class _AdminSkillsViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public _AdminSkillsViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skills = await _appDbContext.Skills
               .AsNoTracking()
               .ToListAsync();

            return View(skills);
        }
    }
}
