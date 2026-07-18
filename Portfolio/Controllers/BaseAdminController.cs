using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [Route("/Admin/[controller]/")]
    public abstract class BaseAdminController : Controller
    {
    }
}
