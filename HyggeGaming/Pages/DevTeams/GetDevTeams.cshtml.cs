using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.DevTeams
{
    public class GetDevTeamsModel : PageModel
    {
        public IEnumerable<DevTeam>? DevTeam { get; set; }
        IDevTeamService DevTeamService { get; set; }

        public GetDevTeamsModel(IDevTeamService service)
        {
            DevTeamService = service;
        }

        public void OnGet()
        {
            DevTeam = DevTeamService.GetDevTeams();
        }
    }
}
