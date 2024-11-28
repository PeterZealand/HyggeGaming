
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFEmployeeService: IEmployeeService
    {
        private HGDBContext context;

        public Employee Employee { get; set; }

        public EFEmployeeService(HGDBContext service)
        {
            context = service;
        }

        public Employee CheckCredentials(Employee employee)
        {
            context.Employees.
                FirstOrDefault(e => e.Mail == employee.Mail);

            if (employee != null && employee.Password == employee.Password)
            {
                return employee;
            }
            return null;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee? GetEmployee(string employeeMail)
        {
            return context.Employees
                .Include(e => e.Role)
                .Include(e => e.ZipCodeNavigation)
                .FirstOrDefault(e => e.Mail == employeeMail);
        }

        public IEnumerable<Employee>? GetTeamMembers(Employee emp)
        {
            return context.Employees
                .Where(e => e.DevTeamId == emp.DevTeamId && e.EmployeeId != emp.EmployeeId)
                .Include(e => e.Role)
                .ToList();
        }


    }
}
