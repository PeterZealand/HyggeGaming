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
        public string SuccessMsg = string.Empty;

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
            EmployeeService.CheckCredentials(Employee);
            if (Employee != null)
            {
                HttpContext.Session.SetString("LoggedIn", Employee.Mail);
                return RedirectToPage("/Employees/Profile");
            }
            return Page();
        }
    }
}
