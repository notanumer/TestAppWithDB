﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Domain.Model;
using TestAppWithDB.Models;

namespace TestAppWithDB.Controllers
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
            var player = new Player() { FirstName = "Nikita", LastName = "Kolchin" };
            return View(player);
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