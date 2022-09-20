using TestApp.Domain.Model;
using TestApp.Domain.Response;
using TestAppWithDB.DAL.Interfaces;
using TestAppWithDB.Service.Interfaces;
using TestApp.Domain.Enum;

namespace TestAppWithDB.Service.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _player;

        public PlayerService(IPlayerRepository player)
        {
            _player = player;
        }
        public async Task<IBaseResponse<IEnumerable<Player>>> GetPlayersAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Player>>();
            try
            {
                var players = await _player.SelectAsync();

                if (players.Count == 0)
                {
                    baseResponse.ExceptionDescription = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = players;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Player>>()
                {
                    ExceptionDescription = ex.Message
                };
            }
        }
    }
}
