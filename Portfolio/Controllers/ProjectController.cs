using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projectList= _context.Projects.ToList();
            return View(projectList);
        }


        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if(!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index", "Project");
        }




        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var project= _context.Projects.Find(id);
            return View(project);
        }




        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            if(!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index", "Project");
        }

       


        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index", "Project");
        }

    }
}
