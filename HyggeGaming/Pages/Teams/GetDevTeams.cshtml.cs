using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Teams
{
    public class GetDevTeamsModel : PageModel
    {
        private readonly IDevTeamService DevTeamService;
        public IEnumerable<DevTeam>? DevTeam { get; set; }

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
