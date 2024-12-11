using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
namespace HyggeGaming.Pages.Employees
{
    public class UpdateEmployeeModel : PageModel
    {

        private readonly IEmployeeService EmployeeService;

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
            EmployeeService.UpdateEmployee(Emp);

            return RedirectToPage("/Employees/AllEmployees");

        }
    }
}
