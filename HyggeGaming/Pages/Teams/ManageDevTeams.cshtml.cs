using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Teams
{
    public class ManageDevTeamsModel : PageModel
    {
        private readonly IDevTeamService DevTeamService;
        private readonly IEmployeeService EmployeeService;

        [BindProperty]
        public DevTeam DevT { get; set; }
        public IEnumerable<DevTeam>? DevTeams { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        

        [BindProperty (SupportsGet = true)]
        public string? SearchString { get; set; }

        public ManageDevTeamsModel(IDevTeamService service, IEmployeeService empService)
        {
            DevTeamService = service;
            EmployeeService = empService;
        }

        public void OnGet()
        {
            Employees = EmployeeService.GetEmployees();
            DevTeams = DevTeamService.GetDevTeams();

            if (!String.IsNullOrEmpty(SearchString))
            {
                DevTeams = DevTeamService.TeamSearch(SearchString);
            }
            else
            {
                DevTeams = DevTeamService.GetDevTeams();
            } 
        }

        public IActionResult OnPostAssignEmp()
        {

            var teamIdString = Request.Form["DevT.DevTeamId"];
            Console.WriteLine($"Raw Form Value for DevT.DevTeamId: {teamIdString}");

            if (int.TryParse(teamIdString, out int teamId))
            {
                Console.WriteLine($"Parsed DevTeamId: {teamId}");
                DevT.DevTeamId = teamId;
            }
            else
            {
                Console.WriteLine("Invalid input for DevTeamId.");
                return Page();
            }
            EmployeeService.AssignEmpToTeam(Employee, DevT);
            return RedirectToPage();
        }
    }
}
