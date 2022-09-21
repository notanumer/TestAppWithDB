using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.Service.Interfaces;
using TestAppWithDB.ViewModels;

namespace TestAppWithDB.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private HashSet<string> _teams = new();

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        async Task GetTeams()
        {
            var response = await _playerService.GetPlayersAsync();
            _teams = response.Data
                .Select(player => player.TeamName)
                .ToHashSet();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var response = await _playerService.GetPlayersAsync();
            if (response.StatusCode == TestApp.Domain.Enum.StatusCode.OK)
                return View(response.Data.OrderBy(player => player.TeamName));
            else
                return View("Error", response.ExceptionDescription);
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
                await _playerService.CreateAsync(player);
                return View("Thanks");
            }
            else
                return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _playerService.GetPlayerAsync(id);
            var tp = new TeamsAndPlayers() { Player = player.Data, Teams = _teams };
            return View(tp);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(Player player)
        {
            await _playerService.UpdateAsync(player);
            return RedirectToAction("GetPlayers");
        }
    }
}
