using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;

namespace HyggeGaming.Pages.Games
{
    public class ManageGamesModel : PageModel
    {
        public IGameService GameService { get; set; }
        public IEnumerable<Game> games { get; set; }

        public ManageGamesModel(IGameService service)
        {
            GameService = service;
        }

        public void OnGet()
        {
            games = GameService.GetGames();
        }
    }
}
