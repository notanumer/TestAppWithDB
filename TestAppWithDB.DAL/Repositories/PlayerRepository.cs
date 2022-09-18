using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Model;
using TestAppWithDB.DAL.Interfaces;

namespace TestAppWithDB.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _db;

        public PlayerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Player model)
        {
            await _db.Player.AddAsync(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public bool Delete(Player model)
        {
            throw new NotImplementedException();
        }

        public Player Get(string firstName)
        {
            throw new NotImplementedException();
        }

        public Player GetByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> Select()
        {
            return _db.Player.ToListAsync();
        }
    }
}
