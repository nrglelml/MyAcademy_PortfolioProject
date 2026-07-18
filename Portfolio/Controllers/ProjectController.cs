using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System;

namespace Portfolio.Controllers
{
    public class ProjectController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public ProjectController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        [HttpGet("CreateProject")]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost("CreateProject")]
        public IActionResult CreateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("UpdateProject/{id}")]
        public IActionResult UpdateProject(int id)
        {
            var project = _context.Projects.Find(id);
            return View(project);
        }

        [HttpPost("UpdateProject")]
        public IActionResult UpdateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet("DeleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}