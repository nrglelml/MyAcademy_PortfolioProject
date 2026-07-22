using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class DashboardController : BaseAdminController
    {
        private readonly AppDBContext _context;
        public DashboardController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalProjects = _context.Projects.Count(),
                TotalTechStacks = _context.TechStacks.Count(),
                TotalMessages = _context.UserMessages.Count(),
                TotalTestimonials = _context.Testimonials.Count(),
                TotalSkills = _context.Skills.Count(s => s.IsActive),
                RecentMessages = _context.UserMessages
                    .OrderByDescending(m => m.Id)
                    .Take(5)
                    .Select(m => new RecentMessageItem
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Email = m.Email,
                        MessageBody = m.MessageBody
                    })
                    .ToList()
            };

            return View(viewModel);
        }
    }
}