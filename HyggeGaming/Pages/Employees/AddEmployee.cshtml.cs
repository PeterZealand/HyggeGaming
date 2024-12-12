using HyggeGaming.Models;
using HyggeGaming.Services.EFService;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        IEmployeeService EmployeeService { get; set; }
        [BindProperty]           
        public Employee Emp { get; set; }

        private readonly ICityService CityService;
        public IEnumerable<City> Cities { get; set; }
        private readonly IRoleService RoleService;
        public IEnumerable<Role> Roles { get; set; }

        public AddEmployeeModel(IEmployeeService service, ICityService cService, IRoleService rService)
        {
            EmployeeService = service;
            CityService = cService;
            RoleService = rService;
        }


        public IActionResult OnGet()
        {
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
                return Page();
            }

            //Role connection
            var roleString = Request.Form["Emp.Role.RoleId"];
            var role = RoleService.GetRoles().FirstOrDefault(r => r.Role1 == roleString); //Denne kan nok godt flyttes til Service, men det virker for nu
            if (role != null)
            {
                Emp.Role = role;
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

            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            EmployeeService.AddEmployee(Emp);

            return RedirectToPage("/Employees/AllEmployees", new {successMsg = "New employee has been added successfully"});
        }
    }

    //SuccessMsg = "You have added a new employee";
    //    return RedirectToPage("/Employees/AllEmployees");
    //    //return Page();
}