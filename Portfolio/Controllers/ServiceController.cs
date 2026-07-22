using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ServiceController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public ServiceController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
        [HttpGet("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost("CreateService")]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateService/{id}")]
        public IActionResult UpdateService(int id)
        {
            var service = _context.Services.Find(id);
            return View(service);
        }
        [HttpPost("UpdateService")]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteService/{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
