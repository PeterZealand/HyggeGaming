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

        private readonly IDevTeamService DevTeamService;
        private readonly IRoleService RoleService;
        private readonly ICityService CityService;

        [BindProperty]

        public Employee Emp { get; set; }

        public UpdateEmployeeModel(IEmployeeService empService, IDevTeamService teamService, IRoleService roleService, ICityService cityService)
        {
            EmployeeService = empService;
            DevTeamService = teamService;
            RoleService = roleService;
            CityService = cityService;
        }

        public IActionResult OnGet(int? employeeId)
        {
            //ViewData["Title"] = "Update Employee";
            //Console.WriteLine($"Title : {ViewData["Title"]}");

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
            //ViewData["RoleId"] = new SelectList(RoleService.GetRoles(), "RoleId", "RoleName");
            //ViewData["DevTeamId"] = new SelectList(DevTeamService.GetDevTeams(), "DevTeamId", "DevTeamName");
            //ViewData["ZipCode"] = new SelectList(CityService.GetCities(), "ZipCode", "CityName");

            //Console.WriteLine(ViewData["Title"]);

            return Page();
        }


        public IActionResult OnPost(int employeeId)
        {
            //Manually remove fields from validation if needed
            ModelState.Remove("Emp.ZipCodeNavigation");
            ModelState.Remove("Emp.Role");

            if (!ModelState.IsValid)
            {
                //ViewData["RoleId"] = new SelectList(RoleService.GetRoles(), "RoleId", "RoleName");
                //ViewData["DevTeamId"] = new SelectList(DevTeamService.GetDevTeams(), "DevTeamId", "DevTeamName");
                //ViewData["ZipCode"] = new SelectList(CityService.GetCities(), "ZipCode", "CityName");

                return Page();
            }
            EmployeeService.UpdateEmployee(Emp);

            return RedirectToPage("/Employees/AllEmployees");

        }
    }
}
