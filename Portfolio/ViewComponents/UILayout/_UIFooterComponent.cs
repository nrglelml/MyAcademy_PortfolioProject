using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIFooterComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIFooterComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var info = _context.ContactInfos.FirstOrDefault();
            return View(info);
        }
    }
}