using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIEducationComponent:ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIEducationComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }
    }
}
