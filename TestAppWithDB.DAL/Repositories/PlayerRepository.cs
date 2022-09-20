﻿using Microsoft.EntityFrameworkCore;
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
            _db.Player.Remove(model);
            _db.SaveChanges();
            return true;
        }

        public async Task<Player> GetAsync(string firstName)
        {
            return await _db.Player.FirstOrDefaultAsync(player => player.FirstName == firstName);
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
