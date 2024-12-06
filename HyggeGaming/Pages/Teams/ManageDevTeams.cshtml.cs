using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Teams
{
    public class ManageDevTeamsModel : PageModel
    {
        public IEnumerable<DevTeam>? DevTeam { get; set; }
        IDevTeamService DevTeamService { get; set; }
        [BindProperty]
        public DevTeam DevT { get; set; }
        public ManageDevTeamsModel(IDevTeamService service)
        {
            DevTeamService = service;
        }

        public void OnGet()
        {
            DevTeam = DevTeamService.GetDevTeams();
        }
    }
}
