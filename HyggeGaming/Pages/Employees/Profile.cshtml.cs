using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class ProfileModel : PageModel
    {
        private readonly IEmployeeService EmployeeService;
        private readonly IAssignmentService AssignmentService;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Employee? Employee { get; set; }

        [BindProperty]
        public Game Game { get; set; }
        [BindProperty]
        public Assignment assignment { get; set; }
        [BindProperty]
        public IEnumerable<Assignment> Assignments { get; set; }
        public List<string> Statuses { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public ProfileModel(IEmployeeService service, IAssignmentService aService)
        {
            EmployeeService = service;
            AssignmentService = aService;
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
                
                var teamManagers = Employee.DevTeam?.TeamManagers;
                if(teamManagers != null)
                {
                    Game = teamManagers.FirstOrDefault()?.Game;
                    Assignments = Game?.Assignments;
                    Statuses = AssignmentService.Statuses();
                }
                
                return Page();
            }

            return RedirectToPage("/Employees/Login");
        }

        public IActionResult OnPost(int employeeId)
        {   
                //Manually remove fields from validation if needed
                ModelState.Remove("Emp.ZipCodeNavigation");
                ModelState.Remove("Emp.Role");

                if (!ModelState.IsValid)
                {
                    
                    return Page();
                }
                EmployeeService.UpdateEmployee(Employee);

                return RedirectToPage("/Employees/Profile");

        }

        public IActionResult OnPostEdit()
        {
            //Ingen ModelState validation fordi det kun er et felt som opdateres og dette er en dropdown
            AssignmentService.UpdateAssignment(assignment);

            return RedirectToPage();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Employees/Login");
        }

        public IActionResult OnPostChangePassword(int employeeId, string newPassword, string confirmPassword)
        {

            if (newPassword == confirmPassword)
            {
                Employee = EmployeeService.GetEmployeeForUpdating(employeeId);
                if (Employee != null)
                {
                    Employee.Password = newPassword;
                    EmployeeService.UpdateEmployee(Employee);
                }

                return RedirectToPage("/Employees/Profile");
            }
            else
            {
                var loggedInEmployee = HttpContext.Session.GetString("LoggedIn");

                if (!string.IsNullOrEmpty(loggedInEmployee))
                {
                    Employee = EmployeeService.GetEmployee(loggedInEmployee);
                }

                ErrorMessage = "Password not changed - make sure passwords are identical";
                return Page();
            }

        }
    }
}
