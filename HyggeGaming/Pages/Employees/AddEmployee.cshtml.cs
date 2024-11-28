using HyggeGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        private readonly HGDBContext dbContext;

        public string SuccessMsg = string.Empty;

        [BindProperty(SupportsGet = true)]
        public Employee Emp { get; set; }


        public AddEmployeeModel(HGDBContext context) => dbContext = context;
        public void OnGet(int? employeeId)
        {
            if (employeeId.HasValue)
            {
                Emp = dbContext.Employees.Find(employeeId.Value);
            }
            else
            {
                Emp = new Employee();
            }
        }

        public IActionResult OnPost(int employeeId)
        {


            dbContext.Employees.Add(Emp);
            dbContext.SaveChanges();

            SuccessMsg = "You have added a new employee";
            return RedirectToPage("/Employees/Profile");
            //return Page();
        }




    }
}



