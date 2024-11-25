using HyggeGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Pages.Employees
{
    public class ProfileModel : PageModel
    {
        public Employee Employee { get; set; }
        public HGDBContext HGDBContext { get; set; }

        public ProfileModel(HGDBContext context)
        {
            HGDBContext = context;
        }

        public IActionResult OnGet()
        {
            var loggedInEmployee = HttpContext.Session.GetString("LoggedIn");
            //Console.WriteLine($"Mail: {Employee.Mail}");

            if (!string.IsNullOrEmpty(loggedInEmployee))
            {
                Employee = HGDBContext.Employees
                    .Include(e => e.Role)
                    .Include(e => e.ZipCodeNavigation)
                    .FirstOrDefault(e => e.Mail == loggedInEmployee);
                return Page();
            }

            if (Employee == null)
            {
                
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



        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Employees/Login");
        }
    }
}
