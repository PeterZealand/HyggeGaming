using HyggeGaming.Models;
using HyggeGaming.Services.EFService;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Teams
{
    public class DevTeamModel : PageModel
    {
        [BindProperty]
        public DevTeam? DevTeam { get; set; }
        [BindProperty]
        public Employee? Employee { get; set; }
        IEmployeeService EmployeeService { get; set; }
        IDevTeamService DevTeamService { get; set; }
        public IEnumerable<DevTeam> DevTeams { get; set; }
        public IEnumerable<Employee>? Employees { get; private set; }

        public DevTeamModel(IEmployeeService service)
        {
            EmployeeService = service;
        }


        public IActionResult OnGet()
        {
            var loggedInEmployee = HttpContext.Session.GetString("LoggedIn");

            if (!string.IsNullOrEmpty(loggedInEmployee))
            {
                Employee = EmployeeService.GetEmployee(loggedInEmployee);

            }

            if (Employee != null)
            {
                Employees = EmployeeService.GetTeamMembers(Employee);
                return Page();
            }

            return RedirectToPage("/Employees/Login");
        }
    }
}
