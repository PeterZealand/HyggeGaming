using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Pages.Employees
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public Employee? Employee { get; set; }

        IEmployeeService EmployeeService { get; set; }
        //IDevTeamService DevTeamService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public ProfileModel(IEmployeeService service)
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
        //    DevT = HGDBContext.Employees
        //        .Include(e => e.Role)
        //        .FirstOrDefault(e => e.Mail == loggedInEmployee);

        //    if (DevT == null)
        //    {
        //        Console.WriteLine($"No employee found for email: {loggedInEmployee}. Redirecting to Login.");
        //        return RedirectToPage("/Employees/Login");
        //    }

        //    // Step 3: Debugging the DevT object
        //    Console.WriteLine($"DevT loaded: {DevT.FirstName} {DevT.LastName}, Email: {DevT.Mail}");

        //    // Render page
        //    return Page();
        //}



        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Employees/Login");
        }
    }
}
