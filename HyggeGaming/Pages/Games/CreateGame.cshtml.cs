using HyggeGaming.Models;
using HyggeGaming.Pages.Employees;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Games
{
    public class CreateGameModel : PageModel
    {
        public IGameService GameService { get; set; }

        [BindProperty]
        public Game game { get; set; }
        public List<string> devStages { get; set; }

        public CreateGameModel(IGameService service)
        {
            GameService = service;
        }

        public void OnGet()
        {
            devStages = GameService.DevStages();
        }

        public IActionResult OnPost(int gameID)
        {
            if (!ModelState.IsValid)
            {
                devStages = GameService.DevStages(); //Ensure DevStages gets re-rendered when onPost is called
                return Page();
            }

            
            GameService.AddGame(game);

            return RedirectToPage("/Games/ManageGames");
        }
    }
}
