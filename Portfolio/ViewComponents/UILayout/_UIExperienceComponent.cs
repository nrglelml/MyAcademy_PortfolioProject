using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIExperienceComponent:ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIExperienceComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
