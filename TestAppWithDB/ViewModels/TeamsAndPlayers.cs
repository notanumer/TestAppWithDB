using TestApp.Domain.Model;

namespace TestAppWithDB.ViewModels
{
    public class TeamsAndPlayers
    {
        public Player Player { get; set; }
        public IEnumerable<string> Teams { get; set; }
    }
}
