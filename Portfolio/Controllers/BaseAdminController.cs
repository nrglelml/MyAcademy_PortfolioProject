using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [Route("/Admin/[controller]/")]
    [Authorize]
    public abstract class BaseAdminController : Controller
    {
    }
}
