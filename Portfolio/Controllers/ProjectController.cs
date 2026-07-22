using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System;
using System.IO;
using System.Linq;

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
        public IActionResult CreateProject(Project project, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                project.ImageUrl = SaveImageFile(imageFile);
            }

            ModelState.Remove("ImageUrl");

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
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost("UpdateProject")]
        public IActionResult UpdateProject(Project project, IFormFile? imageFile)
        {
            var existingProject = _context.Projects.AsNoTracking().FirstOrDefault(x => x.Id == project.Id);

            if (existingProject != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingProject.ImageUrl))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingProject.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    project.ImageUrl = SaveImageFile(imageFile);
                }
                else
                {
                    project.ImageUrl = existingProject.ImageUrl;
                }
            }

            ModelState.Remove("ImageUrl");

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
            if (project != null)
            {
                if (!string.IsNullOrEmpty(project.ImageUrl))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", project.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                _context.Projects.Remove(project);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private string SaveImageFile(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName);
            var imagename = Guid.NewGuid() + extension;
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "projectImages");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var savelocation = Path.Combine(folder, imagename);

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return "/projectImages/" + imagename;
        }
    }
}