using HyggeGaming.Models;
using Microsoft.AspNetCore.Mvc;

namespace HyggeGaming.Pages.Teams
{
    public interface IDevTeamModel
    {
        DevTeam? DevTeam { get; set; }
       
        IEnumerable<DevTeam> DevTeams { get; set; }
       
        Employee? Employee { get; set; }
       
        IEnumerable<Employee>? Employees { get; }
       

        IActionResult OnGet();
        
    }
}