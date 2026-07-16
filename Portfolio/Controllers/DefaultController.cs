using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AppDBContext _context;

        public DefaultController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(UserMessage message)
        {
            if (ModelState.IsValid)
            {
                 message.Isread = false;  
                await _context.UserMessages.AddAsync(message);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
               return View("Index", message);
            }
        }
    }
}
