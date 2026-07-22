using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Models.ProjectStack;

namespace Portfolio.ViewComponents.AdminDashboard
{
    public class _RecentProjectsViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        public _RecentProjectsViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {

            var recenetProjectList=   _appDbContext.ProjectTechStacks
               .Include(x => x.Project)
               .Include(x => x.TechStack)
               .GroupBy(x => new { x.ProjectId, x.Project.Name })
               .Select(g => new ProjectStackListViewModel
               {
                   ProjectName = g.Key.Name,
                   TechStackNames = g.Select(x => x.TechStack.Name).ToList(),
                   CreatedAt = g.Select(x => x.Project.CreatedAt).FirstOrDefault()
               })
               .OrderByDescending(x => x.CreatedAt)
               .Take(5)
               .ToList();

          
            return View(recenetProjectList);
        }
    }
}
