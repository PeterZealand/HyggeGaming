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
    //public class DeleteEmployeeModel : PageModel
    //{
    //    private readonly HGDBContext _context;

    //    public DeleteEmployeeModel(HGDBContext context)
    //    {
    //        _context = context;
    //    }

    //    [BindProperty]
    //    public Employee Emp { get; set; } = default!;

    //    public async Task<IActionResult> OnGetAsync(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);

    //        if (employee == null)
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            Emp = employee;
    //        }
    //        return Page();
    //    }

    //    public async Task<IActionResult> OnPostAsync(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.Employees.FindAsync(id);
    //        if (employee != null)
    //        {
    //            Emp = employee;
    //            _context.Employees.Remove(Emp);
    //            await _context.SaveChangesAsync();
    //        }

    //        return RedirectToPage("/Employees/AllEmployees");
    //    }
    //}

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

