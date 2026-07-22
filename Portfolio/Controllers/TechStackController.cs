using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TechStackController : BaseAdminController
    {

        private readonly AppDBContext _context;
        public TechStackController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var techs = _context.TechStacks.ToList();
            return View(techs);
        }
        [HttpGet("CreateTechStack")]
        public IActionResult CreateTechStack()
        {
            return View();
        }
        [HttpPost("CreateTechStack")]
        public IActionResult CreateTechStack(TechStack techStack)
        {
            _context.TechStacks.Add(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateTechStack/{id}")]
        public IActionResult UpdateTechStack(int id)
        {
            var techStack = _context.TechStacks.Find(id);
            return View(techStack);
        }
        [HttpPost("UpdateTechStack")]
        public IActionResult UpdateTechStack(TechStack techStack)
        {
            _context.TechStacks.Update(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteTechStack/{id}")]
        public IActionResult DeleteTechStack(int id)
        {
            var techStack = _context.TechStacks.Find(id);
            _context.TechStacks.Remove(techStack);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
