using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using HyggeGaming.Filters;

namespace HyggeGaming.Pages.Employees
{
    [AuthFilter]
    public class AllEmployeesModel : PageModel
    {
        private readonly IEmployeeService EmployeeService;
        public IEnumerable<Employee>? Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty (SupportsGet = true)]
        public string? successMsg { get; set; }

        public AllEmployeesModel(IEmployeeService context)
        {
            EmployeeService = context;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                Employees = EmployeeService.SearchEmployee(SearchString);
            }
            else
                Employees = EmployeeService.GetEmployees();
        }
    }
}

