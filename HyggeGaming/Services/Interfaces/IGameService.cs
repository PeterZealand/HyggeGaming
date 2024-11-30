using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IGameService
    {
        public IEnumerable<Game> GetGames();
        public void AddGame(Game newGame);
        public List<string> DevStages();
    }
}
