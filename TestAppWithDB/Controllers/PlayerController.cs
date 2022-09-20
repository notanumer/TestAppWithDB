using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.ViewModels;

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
        public async Task<IActionResult> RsvpForm()
        {
            var respons = await _player.Select();
            var res = new HashSet<string>();
            var plre = new Player();
            foreach (var plr in respons)
                res.Add(plr.TeamName);
            var tp = new TeamsAndPlayers() { Player = plre, Teams = res };
            return View(tp);
        }

        [HttpPost]
        public async Task<IActionResult> RsvpForm(Player player)
        {
            if (ModelState.IsValid)
            {
                await _player.Create(player);
                return View("Thanks");
            }
            else
                return View();
        }
    }
}
