using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Pages.Employees
{
    public class UpdateEmployeeModel : PageModel
    {
        private readonly HGDBContext _context;
        public UpdateEmployeeModel(HGDBContext context)
        {
            _context = context;
        }

        private readonly IEmployeeService employeeService;

        [BindProperty]
        public Employee Emp { get; set; }

       
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);

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

        public IActionResult OnPost()
        {
           

            return RedirectToPage("/Employees/AllEmployees");
        }
    }
}
