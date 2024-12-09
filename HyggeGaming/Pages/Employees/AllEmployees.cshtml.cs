using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Employees
{
    public class AllEmployeesModel : PageModel
    {
        public IEnumerable<Employee>? Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        IEmployeeService EmployeeService { get; set; }

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

