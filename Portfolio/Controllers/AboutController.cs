using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class AboutController : BaseAdminController
    {
        private readonly AppDBContext _context;
        public AboutController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }

        [HttpGet("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost("CreateAbout")]
        public IActionResult CreateAbout(About about, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                about.ImageUrl = SaveImageFile(imageFile);
            }

            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("UpdateAbout/{id}")]
        public IActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost("UpdateAbout")]
        public IActionResult UpdateAbout(About about, IFormFile? imageFile)
        {
            var existingAbout = _context.Abouts.AsNoTracking().FirstOrDefault(x => x.Id == about.Id);

            if (existingAbout != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingAbout.ImageUrl))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingAbout.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    about.ImageUrl = SaveImageFile(imageFile);
                }
                else
                {
                    about.ImageUrl = existingAbout.ImageUrl;
                }
            }

            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about != null)
            {
                if (!string.IsNullOrEmpty(about.ImageUrl))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", about.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                _context.Abouts.Remove(about);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private string SaveImageFile(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName);
            var imagename = Guid.NewGuid() + extension;
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "aboutImages");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var savelocation = Path.Combine(folder, imagename);

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return "/aboutImages/" + imagename;
        }
    }
}
