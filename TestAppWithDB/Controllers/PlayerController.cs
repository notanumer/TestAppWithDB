using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var response = await _player.Select();
            return View(response);
        }
    }
}
