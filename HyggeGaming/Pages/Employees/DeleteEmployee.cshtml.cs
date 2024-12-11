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
    public class DeleteEmployeeModel : PageModel
    {
        private readonly IEmployeeService EmployeeService;

        public DeleteEmployeeModel(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [BindProperty]
        public Employee Emp { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = EmployeeService.GetEmployeeForUpdating(id.Value);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Emp = employee;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = EmployeeService.GetEmployeeForUpdating(id.Value);
            if (employee != null)
            {
                Emp = employee;
                EmployeeService.DeleteEmployee(Emp);
            }

            return RedirectToPage("/Employees/AllEmployees");
        }
    }
}

