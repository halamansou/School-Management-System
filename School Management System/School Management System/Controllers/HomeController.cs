using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using System.Diagnostics;

namespace School_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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





        public IActionResult contact()
        {
            return View("contact");
        }

        public IActionResult about()
        {
            return View("about");
        }

        public IActionResult teacher()
        {
            return View("teacher");
        }


        public IActionResult vehicle()
        {
            return View("vehicle");
        }
    }
}
