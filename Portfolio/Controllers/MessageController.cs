using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class MessageController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public MessageController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var messages = _context.UserMessages.ToList();
            return View(messages);
        }
        [HttpPost("ReadMessageApi/{id}")]
        public IActionResult ReadMessageApi(int id)
        {
            var message = _context.UserMessages.Find(id);
            if (message != null)
            {
                message.Isread = true;
                _context.SaveChanges();
                return Ok(new { success = true });
            }
            return NotFound();
        }


        [HttpGet("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.UserMessages.Find(id);
            _context.UserMessages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

