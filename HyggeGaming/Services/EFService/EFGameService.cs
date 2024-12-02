using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

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
