using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIBannerComponent:ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIBannerComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values=_context.Banners.FirstOrDefault();
            return View(values);
        }
    }
}
