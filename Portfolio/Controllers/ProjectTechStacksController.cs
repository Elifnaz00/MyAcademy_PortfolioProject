using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
   
    public class ProjectTechStacksController : Controller
    {

        private readonly AppDbContext _context;

        public ProjectTechStacksController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var list= _context.ProjectTechStacks.Include(x=> x.Project).Include(x=> x.TechStack).ToList();
            return View(list);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var projects = _context.Projects.ToList();   
            var techStacks = _context.TechStacks.ToList();   

            ViewBag.Projects = (from project in projects
                                select new SelectListItem
                                {
                                    Value = project.Id.ToString(),
                                    Text = project.Name
                                }).ToList();

            ViewBag.TechStacks = (from techStack in techStacks
                                  select new SelectListItem
                                  {
                                      Value = techStack.Id.ToString(),
                                      Text = techStack.Name
                                  }).ToList();  


            return View();
        }


        [HttpPost]
        public IActionResult Create(ProjectTechStack projectTechStack)
        {
            var list = _context.ProjectTechStacks.Add(projectTechStack);    
            _context.SaveChanges(); 
            return RedirectToAction("Index", "ProjectTechStacks");
        }
    }
}
