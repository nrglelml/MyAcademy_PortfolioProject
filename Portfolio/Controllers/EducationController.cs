using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly AppDBContext _context;

        public EducationController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var education = _context.Educations.ToList();
            return View(education);
        }
        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEducation(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEducation(int id)
        {
            var education = _context.Educations.Find(id);
            return View(education);
        }
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Educations.Find(id);
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
            
