using Megazine_Practice.Models;
using Megazine_Practice.Services.ServiceImpl;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Megazine_Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserActivityFilter _userActivityFilter;
       

        public HomeController(ILogger<HomeController> logger, IUserActivityFilter userActivityFilter)
        {
            _logger = logger;
            _userActivityFilter = userActivityFilter;
        }

        public IActionResult Index()
        {
            
            
            List<UserActivity> myModels = _userActivityFilter.GetAll();
      
            return View(myModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}