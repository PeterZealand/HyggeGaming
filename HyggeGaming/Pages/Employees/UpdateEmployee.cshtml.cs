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

        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Role> Roles { get; set; }

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

            Cities = CityService.GetCities();
            Roles = RoleService.GetRoles();

            return Page();
        }

        public IActionResult OnPost(int employeeId)
        {
            //Zipcode connection
            var cityString = Request.Form["Emp.ZipCode"];
            if (int.TryParse(cityString, out int zipcodeInt))
            {
                Console.WriteLine($"Parsed zipcodeInt: {zipcodeInt}");
                Emp.ZipCode = zipcodeInt;
            }
            else
            {
                Console.WriteLine("Invalid input for zipcodeInt.");
                return RedirectToPage();
            }

            //Role connection
            var roleIdString = Request.Form["Emp.RoleId"];
            if (int.TryParse(roleIdString, out int roleId))
            {
                Emp.RoleId = roleId; // Directly set RoleId
            }
            
            else
            {
                Console.WriteLine("Invalid input for role.");
                return RedirectToPage();
            }

            //Manually remove fields from validation if needed
            ModelState.Remove("Emp.ZipCodeNavigation");
            ModelState.Remove("Emp.Role.Role1");
            ModelState.Remove("Emp.Role.RoleId");
            ModelState.Remove("Emp.Role");

            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            EmployeeService.UpdateEmployee(Emp);

            return RedirectToPage("/Employees/AllEmployees");
        }
    }
}
