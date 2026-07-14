using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectTechStackController : Controller
    {
        private readonly AppDBContext _context;

        public ProjectTechStackController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projectGroups = _context.ProjectTechStacks
           .Include(p => p.Project)
           .Include(t => t.TechStack)
           .Where(x => x.Project != null && x.TechStack != null)
           .ToList() 
           .GroupBy(x => x.Project) 
           .Select(group => new ProjectViewModel 
           {
               ProjectName = group.Key.Name,
               TechNames = string.Join(", ", group.Select(x => x.TechStack.Name))
           })
           .ToList();

            return View(projectGroups);
        }
        public IActionResult Create()
        {
            var projects = _context.Projects.ToList();
            var techStacks = _context.TechStacks.ToList();
            ViewBag.projects = (from project in projects
                                select new SelectListItem
                                {
                                    Text = project.Name,
                                    Value = project.Id.ToString()
                                }).ToList();
            ViewBag.techStacks = (from techStack in techStacks
                                  select new SelectListItem
                                  {
                                      Text = techStack.Name,
                                      Value = techStack.Id.ToString()
                                  }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectTechStack projectTechStack)
        {
            ModelState.Remove("Project");
            ModelState.Remove("TechStack");

            if (ModelState.IsValid)
            {
                _context.ProjectTechStacks.Add(projectTechStack);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projects = _context.Projects.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            ViewBag.techStacks = _context.TechStacks.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            }).ToList();

            return View(projectTechStack);
        }

        public IActionResult Update(int id)
        {
            var projectTechStack = _context.ProjectTechStacks.Find(id);
            var projects = _context.Projects.ToList();
            var techStacks = _context.TechStacks.ToList();
            ViewBag.projects = (from project in projects
                                select new SelectListItem
                                {
                                    Text = project.Name,
                                    Value = project.Id.ToString()
                                }).ToList();
            ViewBag.techStacks = (from techStack in techStacks
                                  select new SelectListItem
                                  {
                                      Text = techStack.Name,
                                      Value = techStack.Id.ToString()
                                  }).ToList();
            return View(projectTechStack);
        }
        [HttpPost]
        public IActionResult Update(ProjectTechStack projectTechStack)
        {
            if (!ModelState.IsValid)
            {
                return View(projectTechStack);
            }
            _context.ProjectTechStacks.Update(projectTechStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var projectTechStack = _context.ProjectTechStacks.Find(id);
            _context.ProjectTechStacks.Remove(projectTechStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
