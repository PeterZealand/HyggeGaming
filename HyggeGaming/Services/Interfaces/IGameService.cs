using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IGameService
    {
        public IEnumerable<Game> GetGames();
        public void AddGame(Game newGame);
        public void UpdateGame(Game updateGame);
        public List<string> DevStages();
        Game UpdateGame(object updateGame);
        public Game? GetGameForUpdating(int gameId);
    }
}
