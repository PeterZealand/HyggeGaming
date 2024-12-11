using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Public
{
    public class OurGamesModel : PageModel
    {
        //public GameObject GameObject {  get; set; }
        public IEnumerable<Game> Game { get; set; }
        public IGameService GameService { get; set; }

        public OurGamesModel(IGameService service)
        {
            GameService = service;
        }

        public void OnGet()
        {
            Game = GameService.GetGames();
        }
    }
}
