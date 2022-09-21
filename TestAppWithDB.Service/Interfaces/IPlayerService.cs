using TestApp.Domain.Model;
using TestApp.Domain.Response;

namespace TestAppWithDB.Service.Interfaces
{
    public interface IPlayerService
    {
        Task<IBaseResponse<IEnumerable<Player>>> GetPlayersAsync();
        Task<IBaseResponse<Player>> GetPlayerAsync(int id);
        Task<IBaseResponse<bool>> UpdateAsync(Player player);
        Task<IBaseResponse<bool>> CreateAsync(Player player);
    }
}
