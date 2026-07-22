using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class SkillsController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public SkillsController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }
        [HttpGet("CreateSkill")]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost("CreateSkill")]
        public IActionResult CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateSkill/{id}")]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            return View(skill);
        }
        [HttpPost("UpdateSkill")]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteSkill/{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
