using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Employees
{
    public class UpdateEmployeeModel : PageModel
    {

        IEmployeeService EmployeeService { get; set; }

        [BindProperty]

        public Employee Emp { get; set; }

        public UpdateEmployeeModel(IEmployeeService service)
        {
            EmployeeService = service;
        }

        public IActionResult OnGet(int? employeeId)
        {
            if (employeeId == null)

            {
                return NotFound();
            }

            // Fetch the employee with related data
            Emp = EmployeeService.GetEmployeeForUpdating(employeeId.Value);

            if (Emp == null)
            {
                return NotFound();
            }

            // Populate dropdowns for related fields
            ViewData["DevTeamId"] = new SelectList(EmployeeService.GetDevTeams(), "DevTeamId", "DevTeamName", Emp.DevTeamId);
            ViewData["RoleId"] = new SelectList(EmployeeService.GetRoles(), "RoleId", "RoleName", Emp.RoleId);
            ViewData["ZipCode"] = new SelectList(EmployeeService.GetCities(), "ZipCode", "CityName", Emp.ZipCode);

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
}
