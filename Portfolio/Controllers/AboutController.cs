using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateAbout/{id}")]
        public IActionResult UpdateAbout(int id)
        {
            var about=_context.Abouts.Find(id);
            return View(about);
        }
        [HttpPost("UpdateAbout")]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about=_context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
