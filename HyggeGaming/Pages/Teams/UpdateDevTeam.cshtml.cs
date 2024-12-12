using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Pages.Teams
{
    public class UpdateDevTeamModel : PageModel
    {
        private readonly IDevTeamService DevTeamService;

        public UpdateDevTeamModel(IDevTeamService devTeamService)
        {
            DevTeamService = devTeamService;
        }

        [BindProperty]
        public DevTeam DevT { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch DevTeam using the service
            DevT = DevTeamService.GetDevTeams().FirstOrDefault(t => t.DevTeamId == id.Value);

            if (DevT == null)
            {
                return NotFound();
            }

            //DevT = devT;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

                // Update DevTeam using the service
                DevTeamService.UpdateDevTeam(DevT);

            return RedirectToPage("/Teams/ManageDevTeams");
        }
    }
}



