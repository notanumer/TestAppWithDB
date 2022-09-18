using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;

namespace TestAppWithDB.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _player;

        public PlayerController(IPlayerRepository player)
        {
            _player = player;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var response = await _player.Select();
            return View(response);
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RsvpForm(Player player)
        {
            if (ModelState.IsValid)
            {
                await _player.Create(player);
                return View();
            }
            else
                return View();
        }
    }
}
