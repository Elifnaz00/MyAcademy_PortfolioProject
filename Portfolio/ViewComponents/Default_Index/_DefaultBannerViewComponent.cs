using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.Default_Index
{
    public class _DefaultBannerViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public _DefaultBannerViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var banner= _appDbContext.Banners.FirstOrDefault(); 
            return View(banner);
        }
    }
}
