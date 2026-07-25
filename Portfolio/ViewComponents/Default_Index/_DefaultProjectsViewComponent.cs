using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Models.ProjectStack;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultProjectsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultProjectsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var projectStackDetailsVm= await _context.ProjectTechStacks
                .AsNoTracking()
                .Include(x=> x.TechStack).Include(x=> x.Project)
                .GroupBy(x => new { x.ProjectId, x.Project.Name, x.Project.ImageUrl, x.Project.Description, x.Project.GithubUrl })
                .Select(g => new ProjectStackDetailsViewModel
                {
                    ProjectId = g.Key.ProjectId,
                    Name = g.Key.Name,
                    ImageUrl = g.Key.ImageUrl,
                    Description = g.Key.Description,
                    GithubUrl = g.Key.GithubUrl,
                    TechStackNames = g.Select(x => x.TechStack.Name).ToList()
                })
                .ToListAsync();

            return View(projectStackDetailsVm);
        }
    }
}
