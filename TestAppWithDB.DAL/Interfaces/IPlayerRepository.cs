using TestApp.Domain.Model;

namespace TestAppWithDB.DAL.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player GetByTeamName(string teamName);
    }
}
