using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;

namespace Portfolio.ViewComponents.UILayout
{
    public class _UIUserMessageComponent : ViewComponent
    {
     
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
