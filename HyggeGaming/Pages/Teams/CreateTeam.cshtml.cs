using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Teams
{ 
    public class CreateTeamModel : PageModel
    {
        private readonly IDevTeamService DevTeamService;
        private readonly IGameService GameService;

        [BindProperty]
        public DevTeam DevTeam { get; set; }
        [BindProperty]
        public Game Game { get; set; }
        public IEnumerable<Game> Games { get; set; }

        public CreateTeamModel(IDevTeamService service, IGameService gService)
        {
            DevTeamService = service;
            GameService = gService;
        }

        public IActionResult OnGet()
        {
            Games = GameService.GetGames();
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Game.DevelopmentStage");
            ModelState.Remove("Game.GameType");
            ModelState.Remove("Game.GameName");
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            //Create new team
            DevTeamService.CreateDevTeam(DevTeam);

            //Connect the team with chosen game
            DevTeamService.ConnectTeamWithGame(DevTeam.DevTeamId, Game.GameId);

            return RedirectToPage("/Teams/ManageDevTeams");
        }
    }
}
