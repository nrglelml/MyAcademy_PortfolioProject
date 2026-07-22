using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIServiceComponent:ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIServiceComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Services.ToList();
            return View(values);
        }
    }
}
