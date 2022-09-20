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

        public async Task<bool> CreateAsync(Player model)
        {
            await _db.Player.AddAsync(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Player model)
        {
            _db.Player.Remove(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Player> GetAsync(int id)
        {
            return await _db.Player.FirstOrDefaultAsync(player => player.Id == id);
        }

        public Player GetByTeamName(string teamName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> SelectAsync()
        {
            return _db.Player.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Player model)
        {
            _db.Player.Update(model);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
