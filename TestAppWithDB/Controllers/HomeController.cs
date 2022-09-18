using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.Models;

namespace TestAppWithDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlayerRepository _player;

        public HomeController(ILogger<HomeController> logger, IPlayerRepository player)
        {
            _logger = logger;
            _player = player;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _player.Select();
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