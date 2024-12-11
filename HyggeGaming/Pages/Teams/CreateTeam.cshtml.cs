using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Teams
{ 
    public class CreateTeamModel : PageModel
    {
        IDevTeamService DevTeamService { get; set; }

        [BindProperty]
        public DevTeam DevTeam { get; set; }

        public CreateTeamModel(IDevTeamService service)
        {
            DevTeamService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DevTeamService.CreateDevTeam(DevTeam);

            return RedirectToPage("/Teams/ManageDevTeams");
        }
    }
}
