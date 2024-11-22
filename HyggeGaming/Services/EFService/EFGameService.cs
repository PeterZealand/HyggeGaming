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

        public IEnumerable<Game> GetGames()
        {
            return context.Games;
        }
    }
}
