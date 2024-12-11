using HyggeGaming.Models;
using HyggeGaming.Services.EFService;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Pages.Employees
{
    public class ProfileModel : PageModel
    {
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

        IEmployeeService EmployeeService { get; set; }
        IAssignmentService AssignmentService { get; set; }

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

        //public IActionResult OnGet()
        //{
        //    // Step 1: Retrieve session
        //    var loggedInEmployee = HttpContext.Session.GetString("LoggedIn");
        //    if (string.IsNullOrEmpty(loggedInEmployee))
        //    {
        //        Console.WriteLine("Session is empty or expired. Redirecting to Login.");
        //        return RedirectToPage("/Employees/Login");
        //    }
        //    Console.WriteLine($"Logged in user from session: {loggedInEmployee}");

        //    // Step 2: Query the database
        //    Employee = HGDBContext.Employees
        //        .Include(e => e.Role)
        //        .FirstOrDefault(e => e.Mail == loggedInEmployee);

        //    if (Employee == null)
        //    {
        //        Console.WriteLine($"No employee found for email: {loggedInEmployee}. Redirecting to Login.");
        //        return RedirectToPage("/Employees/Login");
        //    }

        //    // Step 3: Debugging the Employee object
        //    Console.WriteLine($"Employee loaded: {Employee.FirstName} {Employee.LastName}, Email: {Employee.Mail}");

        //    // Render page
        //    return Page();
        //}

        public IActionResult OnPostEdit()
        {
            //Ingen ModelState validation fordi det kun er et felt som opdateres og dette er en dropdown
            AssignmentService.UpdateAssignment(assignment);

            return RedirectToPage();
            //OnGet();
            //return RedirectToPage("/Employees/Profile");
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
                //ErrorMessage = "Password er ikke ens.";
                //ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return RedirectToPage("/Employees/Profile");
            }

        }
    }
}
