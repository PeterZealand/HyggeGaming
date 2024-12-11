using HyggeGaming.Models;
using HyggeGaming.Services.EFService;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        IEmployeeService EmployeeService { get; set; }

        [BindProperty]      
       
        public Employee Emp { get; set; }

        public AddEmployeeModel(IEmployeeService service)
        {
            EmployeeService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
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
            EmployeeService.AddEmployee(Emp);

            return RedirectToPage("/Employees/Profile");
        }
    }

    //SuccessMsg = "You have added a new employee";
    //    return RedirectToPage("/Employees/Profile");
    //    //return Page();
}