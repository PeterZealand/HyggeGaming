using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        IEmployeeService EmployeeService { get; set; }

        public string ErrorMsg = string.Empty;

        public LoginModel(IEmployeeService service)
        {
            EmployeeService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {            
            if (EmployeeService.CheckCredentials(Employee))
            {
                HttpContext.Session.SetString("LoggedIn", Employee.Mail);
                return RedirectToPage("/Employees/Profile");
            }
            else
            {               
                ErrorMsg = "Incorrect email or password";
                return Page();
            }
        }
    }
}
