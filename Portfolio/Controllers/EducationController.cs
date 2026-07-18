using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class EducationController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public EducationController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var education = _context.Educations.ToList();
            return View(education);
        }
        [HttpGet("CreateEducation")]
        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost("CreateEducation")]
        public IActionResult CreateEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateEducation/{id}")]
        public IActionResult UpdateEducation(int id)
        {
            var education = _context.Educations.Find(id);
            return View(education);
        }
        [HttpPost("UpdateEducation")]
        public IActionResult UpdateEducation(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteEducation/{id}")]
        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Educations.Find(id);
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
            
