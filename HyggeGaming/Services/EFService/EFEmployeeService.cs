
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFEmployeeService: IEmployeeService
    {
        private HGDBContext context;

        public EFEmployeeService(HGDBContext service)
        {
            context = service;
        }

        public void AddEmployee(Employee Emp)
        {
            context.Employees
                .Include(e => e.Role)
                .Include(e => e.ZipCodeNavigation)
                .ToList();
            context.Employees.Add(Emp);
            context.SaveChanges();
            //return team;
        }

        public void DeleteEmployee(Employee Emp)
        {
            
            context?.Employees .Remove(Emp);
            context?.SaveChanges();
        }

        //public Employee CheckCredentials(Employee employee)
        //{
        //    context.Employees.
        //        FirstOrDefault(e => e.Mail == employee.Mail);

        //    if (employee != null && employee.Password == employee.Password)
        //    {
        //        return employee;
        //    }
        //    return null;
        //}
        public bool CheckCredentials(Employee employee)
        {
            Employee? isEmp = context.Employees.
                FirstOrDefault(e => e.Mail == employee.Mail);

            if (isEmp != null && isEmp.Password == employee.Password)
            {
                return true;
            }
            return false;
        }

       

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees
                  .Include(e => e.DevTeam)
                  .Include(e => e.Role)
                  .Include(e => e.ZipCodeNavigation)
                  .ToList();
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
