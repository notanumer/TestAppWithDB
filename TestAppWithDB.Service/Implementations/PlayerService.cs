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

        public async Task<IBaseResponse<bool>> CreateAsync(Player player)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var newPlayer = await _player.CreateAsync(player);
                baseResponse.Data = newPlayer;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    ExceptionDescription = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Player>> GetPlayerAsync(int id)
        {
            var baseResponse = new BaseResponse<Player>();
            try
            {
                var player = await _player.GetAsync(id);
                if (player == null)
                {
                    baseResponse.ExceptionDescription = "Пользователь не найдет";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                }

                baseResponse.Data = player;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Player>()
                {
                    ExceptionDescription = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
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

        public async Task<IBaseResponse<bool>> UpdateAsync(Player player)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var updatedPlayer = await _player.UpdateAsync(player);
                baseResponse.Data = updatedPlayer;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    ExceptionDescription = ex.Message
                };
            }
        }
    }
}
