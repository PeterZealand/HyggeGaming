using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

//namespace HyggeGaming.Pages.Employees
//{
//    public class AllEmployeesModel : PageModel
//    {

//        public IEnumerable<Employee>? Employees { get; set; }

//        IEmployeeService EmployeeService { get; set; }

//        public AllEmployeesModel(IEmployeeService context)
//        {
//            EmployeeService = context;
//        }



//        public void OnGet()
//        {
//            Employees = EmployeeService.GetEmployees();

//        }
//    }
//}
namespace HyggeGaming.Pages.Employees
{
    public class AllEmployeesModel : PageModel
    {
        public IEnumerable<Employee>? Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        IEmployeeService EmployeeService { get; set; }

        public AllEmployeesModel(IEmployeeService context)
        {
            EmployeeService = context;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                Employees = EmployeeService.SearchEmployee(SearchString);
            }
            else
                Employees = EmployeeService.GetEmployees();
        }


        //public void OnGet(string? searchString)
        //{
        //    SearchString = searchString;

        //    var employees = EmployeeService.GetEmployees();

        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        employees = employees.Where(e =>
        //            e.FirstName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
        //            e.LastName.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
        //    }

        //    Employees = employees;
        //}
    }
}

