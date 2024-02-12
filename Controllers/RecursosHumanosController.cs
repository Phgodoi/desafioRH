using desafioRH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace desafioRH.Controllers
{
    public class RecursosHumanosController : Controller
    {
        private readonly ILogger<RecursosHumanosController> _logger;

        public RecursosHumanosController(ILogger<RecursosHumanosController> logger)
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
    }
}
