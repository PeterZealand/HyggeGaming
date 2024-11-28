using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IGameService
    {
        public IEnumerable<Game> GetGames();

    }
}
