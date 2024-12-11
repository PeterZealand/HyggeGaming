using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Games
{
    public class ViewGamesModel : PageModel
    {
        public IEnumerable<Game> Game { get; set; }

        IGameService GameService { get; set; }

        public ViewGamesModel(IGameService service) 
        { 
            GameService = service;
        }
        public void OnGet()
        {
            Game = GameService.GetGames();
        }
    }
}
