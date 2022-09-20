using TestApp.Domain.Model;
using TestApp.Domain.Response;

namespace TestAppWithDB.Service.Interfaces
{
    public interface IPlayerService
    {
        Task<IBaseResponse<IEnumerable<Player>>> GetPlayersAsync();
    }
}
