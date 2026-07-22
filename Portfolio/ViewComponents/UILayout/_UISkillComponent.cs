using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
namespace Portfolio.ViewComponents.UILayout
{
    public class _UISkillComponent : ViewComponent
    {
        private readonly AppDBContext _context;
        public _UISkillComponent(AppDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var skills = _context.Skills
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .Select(s => s.Name)
                .ToList();

            return View(skills);
        }
    }
}