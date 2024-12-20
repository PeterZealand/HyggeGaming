using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Games
{
    public class UpdateGamesModel : PageModel
    {
        private readonly IGameService GameService;

        [BindProperty]
        public Game GameObject { get; set; }
        public List<string> DevStages { get; set; }

        public UpdateGamesModel(IGameService gameService) 
        { 
            GameService = gameService;
        }   

        public IActionResult OnGet(int? gameId)
        {
            if (gameId == null)
            {
                return NotFound();
            }
            
            GameObject = GameService.GetGameForUpdating(gameId.Value);
            DevStages = GameService.DevStages();

            if (GameObject == null)
            {
                return NotFound();
            }
     
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            GameService.UpdateGame(GameObject);

            return RedirectToPage("/Games/ManageGames");
        }
    }
}
