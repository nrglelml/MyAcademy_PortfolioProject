using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIAboutComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIAboutComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.FirstOrDefault();
            ViewBag.FrontendTechs = string.Join(", ",_context.TechStacks
              .Where(t => t.Category == "Frontend")
              .Select(t => t.Name));

            ViewBag.BackendTechs = string.Join(", ", _context.TechStacks
                .Where(t => t.Category == "Backend")
                .Select(t => t.Name));

            ViewBag.DatabaseTechs = string.Join(", ", _context.TechStacks
               .Where(t => t.Category == "Database")
               .Select(t => t.Name));

            return View(about);
        }
    }
}
