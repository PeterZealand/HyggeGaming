using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFGameService: IGameService
    {
        private HGDBContext context;
        public EFGameService(HGDBContext service)
        {
            context = service;
        }

        public void AddGame(Game newGame)
        {
            context.Games.Add(newGame);
            context.SaveChanges();
        }

        public Game? GetGameForUpdating(int gameId)
        {
            return context.Games      
                .FirstOrDefault(e => e.GameId == gameId);
        }

        public void UpdateGame(Game updateGame)
        {
            var existingGame = context.Games
                .FirstOrDefault(g => g.GameId == updateGame.GameId);

            if (existingGame == null)
            {
                throw new ArgumentException("Game not found");
            }

            existingGame.GameName = updateGame.GameName;
            existingGame.GameType = updateGame.GameType;
            existingGame.DevelopmentStage = updateGame.DevelopmentStage;

            context.SaveChanges();
        }

        public List<string> DevStages()
        {
            return new List<string>
            {
                "Conceptual",
                "In progress",
                "Beta",
                "Released"
            };
        }

        public IEnumerable<Game> GetGames()
        {
            return context.Games; 
        }
    }
}
