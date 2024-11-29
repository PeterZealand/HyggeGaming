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

        IEmployeeService EmployeeService { get; set; }

        public AllEmployeesModel(IEmployeeService context)
        {
            EmployeeService = context;
        }

        

        public void OnGet()
        {
            Employees = EmployeeService.GetEmployees();

        }
    }
}
