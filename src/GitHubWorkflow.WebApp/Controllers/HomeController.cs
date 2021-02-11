using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UnitTestDemo.Lib;
using UnitTestDemo.WebApp.Models;

namespace UnitTestDemo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloService _helloService;

        public HomeController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public IActionResult Index()
        {
            HelloServiceModel helloServiceModel = new()
            {
                UserName = _helloService.UserName,
                HelloMessage = _helloService.GetHelloMessage()
            };

            return View("Index", helloServiceModel);
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
