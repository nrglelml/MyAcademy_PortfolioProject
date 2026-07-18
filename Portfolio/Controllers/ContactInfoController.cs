using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;

namespace Portfolio.Controllers
{
    public class ContactInfoController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public ContactInfoController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var contactinfo = _context.ContactInfos.FirstOrDefault();
            return View(contactinfo);
        }
        [HttpGet("CreateContactInfo")]
        public IActionResult CreateContactInfo()
        {
            return View();
        }
        [HttpPost("CreateContactInfo")]
        public IActionResult CreateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Add(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("UpdateContactInfo/{id}")]
        public IActionResult UpdateContactInfo(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            return View(contactInfo);
        }
        [HttpPost("UpdateContactInfo")]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _context.ContactInfos.Update(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("DeleteContactInfo/{id}")]
        public IActionResult DeleteContactInfo(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            _context.ContactInfos.Remove(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

