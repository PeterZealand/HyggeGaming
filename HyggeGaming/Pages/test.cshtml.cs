using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages
{
    public class testModel : PageModel
    {
        public IEnumerable<Employee> Employee { get; set; }

        IEmployeeService EmployeeService { get; set; }

        public testModel(IEmployeeService service)
        {
            EmployeeService = service;
        }
        public void OnGet()
        {
            Employee = EmployeeService.GetEmployees();
        }
    }
}
