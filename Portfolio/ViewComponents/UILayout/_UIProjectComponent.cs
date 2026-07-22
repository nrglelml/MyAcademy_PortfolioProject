using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Models;
namespace Portfolio.ViewComponents.UILayout
{
    public class _UIProjectComponent : ViewComponent
    {
        private readonly AppDBContext _context;
        public _UIProjectComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var viewModel = _context.ProjectTechStacks
                .Include(p => p.Project)
                .Include(t => t.TechStack)
                .Where(x => x.Project != null && x.TechStack != null)
                .ToList()
                .GroupBy(x => x.Project)
                .Select(group => new ProjectViewModel
                {
                    ProjectId = group.Key.Id,
                    ProjectName = group.Key.Name,
                    Description = group.Key.Description,
                    ImageUrl = group.Key.ImageUrl,
                    TechNames = string.Join(", ", group.Select(x => x.TechStack.Name))
                })
                .Take(5)
                .ToList();

            return View(viewModel);
        }
    }
}