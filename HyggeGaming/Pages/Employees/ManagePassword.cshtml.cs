using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class ManagePasswordModel : PageModel
    {
        public IEnumerable<Employee>? Employee { get; set; }
        IEmployeeService EmployeeService { get; set; }
        [BindProperty]
        public Employee Emp { get; set; }
        public ManagePasswordModel(IEmployeeService service)
        {
            EmployeeService = service;
        }

        public void OnGet()
        {
            //Emp = EmployeeService.GetEmployee();
        }
    }
}
