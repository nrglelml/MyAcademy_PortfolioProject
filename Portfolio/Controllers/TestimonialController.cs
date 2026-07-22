using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDBContext _context;

        public TestimonialController(AppDBContext context)
        {
            _context = context;
        }
        [Route("/ReferansOlustur")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm zorunlu alanları eksiksiz doldurunuz.";
                return View("Index", testimonial);
            }

            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Değerlendirmeniz başarıyla gönderildi. Teşekkür ederiz!";
            return RedirectToAction("Index");
        }
    }
}