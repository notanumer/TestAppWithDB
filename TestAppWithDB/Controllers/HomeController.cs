using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.Models;

namespace TestAppWithDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}