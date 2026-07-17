
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultAboutViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;


        public _DefaultAboutViewComponent(AppDbContext context)
        {
            _context = context;
        }

 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutList = await Task.FromResult(_context.Abouts.ToList());
            return View(aboutList);
        }
    }
}
