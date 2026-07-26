using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using Portfolio.Models.Project;
using System.Diagnostics.Metrics;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var projectList = await _context.Projects
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return View(projectList);
        }

        private async Task<MultiSelectList> GetTechStacks(string[]? selectedValues)
        {
            var techStackList = await _context.TechStacks
                .AsNoTracking()
                .ToListAsync();

            return new MultiSelectList(techStackList, "Id", "Name", selectedValues);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            ViewBag.TechStackList = await GetTechStacks(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project, string[] techSelectListItems)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.YouSelected = techSelectListItems;
                ViewBag.TechStackList = await GetTechStacks(techSelectListItems);

                return View(project);
            }

            try
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Proje oluşturulurken bir hata oluştu.");

                ViewBag.YouSelected = techSelectListItems;
                ViewBag.TechStackList = await GetTechStacks(techSelectListItems);

                return View(project);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project is null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            try
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Proje güncellenirken bir hata oluştu.");
                return View(project);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project is null)
                return NotFound();

            try
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Proje silinirken bir hata oluştu.");
                return View(project);
            }
        }

    }
}
