
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
    }
}
