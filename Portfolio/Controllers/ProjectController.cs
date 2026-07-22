using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        public IActionResult Index()
        {
            var projectList= _context.Projects.OrderByDescending(e => e.CreatedAt).ToList();
            return View(projectList);
        }



        private MultiSelectList GetTechStacks(string[]? selectedValues)
        {
          var techStackList = _context.TechStacks.ToList();

           
            return new MultiSelectList(techStackList, "Id", "Name", selectedValues);

        }



        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.TechStackList = GetTechStacks(null);
            return View();

        }

      

        [HttpPost]
        public IActionResult CreateProject(Project project, string[] techSelectListItems)
          {
            

            if (!ModelState.IsValid)
            {
                ViewBag.YouSelected = ViewBag.TechStackList = GetTechStacks(techSelectListItems); 
                
                return View(project);
            } 
            //_context.Projects.Add(addProjectViewModel);
            //_context.SaveChanges();
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
