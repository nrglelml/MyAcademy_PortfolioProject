using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIContactInfoComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public _UIContactInfoComponent(AppDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var contactInfo = _context.ContactInfos.FirstOrDefault();
            return View(contactInfo);
        }
    }
}