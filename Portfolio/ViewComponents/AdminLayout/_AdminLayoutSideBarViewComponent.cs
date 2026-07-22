using Microsoft.AspNetCore.Mvc;

namespace Portfolio.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.FullName= HttpContext.Session.GetString("FullName");
            return View();
        }

    }
}
