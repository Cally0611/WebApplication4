using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;
using WebApplication4.Service;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly TimedHostedService _timedHostedService;
        //public HomeController(ILogger<HomeController> logger, TimedHostedService timedHostedService)
        //{
        //    _logger = logger;
        //    _timedHostedService = timedHostedService;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Chart()
        {

            //int test = _timedHostedService.ExecutionCount;
           // ViewBag.Message = test;
            return View();
        }

        public IActionResult Home4K()
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