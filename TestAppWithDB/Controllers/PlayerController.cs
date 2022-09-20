using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.ViewModels;
using System.Linq;

namespace TestAppWithDB.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _player;
        private HashSet<string> _teams = new();

        public PlayerController(IPlayerRepository player)
        {
            _player = player;
        }

        async Task GetTeams()
        {
            var response = await _player.SelectAsync();
            _teams = response.Select(player => player.TeamName).ToHashSet();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var response = await _player.SelectAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> RsvpForm()
        {
            await GetTeams();
            var tp = new TeamsAndPlayers() { Player = new Player(), Teams = _teams };
            return View(tp);
        }

        [HttpPost]
        public async Task<IActionResult> RsvpForm(Player player)
        {
            if (ModelState.IsValid)
            {
                await _player.CreateAsync(player);
                return View("Thanks");
            }
            else
                return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _player.GetAsync(id);
            var tp = new TeamsAndPlayers() { Player = player, Teams = _teams };
            return View(tp);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(Player player)
        {
            await _player.UpdateAsync(player);
            return RedirectToAction("GetPlayers");
        }
    }
}
