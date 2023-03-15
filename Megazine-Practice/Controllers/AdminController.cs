using Microsoft.AspNetCore.Mvc;

namespace Megazine_Practice.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
