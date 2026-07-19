using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRDesk.Controllers
{
    [Authorize]
    [Route("")]
    public class DashboardController : Controller
    {
        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
