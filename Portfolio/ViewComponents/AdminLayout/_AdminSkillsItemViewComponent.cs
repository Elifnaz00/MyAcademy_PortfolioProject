using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.AdminLayout
{
    public class _AdminSkillsItemViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _AdminSkillsItemViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skillItems = await _context.SkillItems
                .AsNoTracking()
                .Include(x => x.Skill)
                .ToListAsync();

            return View(skillItems);
        }
    }
}
