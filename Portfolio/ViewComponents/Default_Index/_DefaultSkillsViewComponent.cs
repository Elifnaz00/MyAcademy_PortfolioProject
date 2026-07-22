using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
   

    public class _DefaultSkillsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultSkillsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skillList = _context.Skills.Include(x => x.SkillItems).ToList();
            return View(skillList);
        }
    }
}
