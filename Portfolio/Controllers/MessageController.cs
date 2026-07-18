using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
