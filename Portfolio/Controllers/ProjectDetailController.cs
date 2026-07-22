using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Models;
namespace Portfolio.Controllers
{
    public class ProjectDetailController : Controller
    {
        private readonly AppDBContext _dbContext;
        public ProjectDetailController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/ProjeDetay/{id}")]
        public IActionResult Index(int id)
        {
            var project = _dbContext.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            var techNames = _dbContext.ProjectTechStacks
                .Include(pt => pt.TechStack)
                .Where(pt => pt.ProjectId == id && pt.TechStack != null)
                .Select(pt => pt.TechStack.Name)
                .ToList();

            var viewModel = new ProjectDetailViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                GithubUrl = project.GithubUrl,
                ImageUrl = project.ImageUrl,
                TechNames = techNames
            };

            return View(viewModel);
        }
    }
}