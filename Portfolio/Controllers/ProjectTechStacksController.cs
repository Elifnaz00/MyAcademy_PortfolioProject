
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using Portfolio.Models.ProjectStack;

namespace Portfolio.Controllers
{
   
    public class ProjectTechStacksController : Controller
    {

        private readonly AppDbContext _context;
      
        public ProjectTechStacksController(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task<IActionResult> Index()
        {
            var projectTechStacksList = await _context.ProjectTechStacks
                .AsNoTracking()
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
                .ToListAsync();

            return View(projectTechStacksList);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projects = await _context.Projects
                .AsNoTracking()
                .ToListAsync();

            var techStacks = await _context.TechStacks
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Projects = projects.Select(project => new SelectListItem
            {
                Value = project.Id.ToString(),
                Text = project.Name
            }).ToList();

            ViewBag.TechStacks = techStacks.Select(techStack => new SelectListItem
            {
                Value = techStack.Id.ToString(),
                Text = techStack.Name
            }).ToList();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProjectTechStack projectTechStack)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = (await _context.Projects.AsNoTracking().ToListAsync())
                    .Select(project => new SelectListItem
                    {
                        Value = project.Id.ToString(),
                        Text = project.Name
                    }).ToList();

                ViewBag.TechStacks = (await _context.TechStacks.AsNoTracking().ToListAsync())
                    .Select(techStack => new SelectListItem
                    {
                        Value = techStack.Id.ToString(),
                        Text = techStack.Name
                    }).ToList();

                return View(projectTechStack);
            }

            try
            {
                await _context.ProjectTechStacks.AddAsync(projectTechStack);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Kayıt oluşturulurken bir hata oluştu.");

                ViewBag.Projects = (await _context.Projects.AsNoTracking().ToListAsync())
                    .Select(project => new SelectListItem
                    {
                        Value = project.Id.ToString(),
                        Text = project.Name
                    }).ToList();

                ViewBag.TechStacks = (await _context.TechStacks.AsNoTracking().ToListAsync())
                    .Select(techStack => new SelectListItem
                    {
                        Value = techStack.Id.ToString(),
                        Text = techStack.Name
                    }).ToList();

                return View(projectTechStack);
            }
        }
    }
}
