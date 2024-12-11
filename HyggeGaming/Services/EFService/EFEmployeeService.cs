using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace HyggeGaming.Services.EFService
{
    public class EFEmployeeService : IEmployeeService
    {
        private HGDBContext context;

        //Skal de bruges?
        public IEnumerable<DevTeam> GetDevTeams()
        {
            return context.DevTeams.ToList();
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public IEnumerable<City> GetCities()
        {
            return context.Cities.ToList();
        }
        //

        public EFEmployeeService(HGDBContext service)
        {
            context = service;
        }

        public void AddEmployee(Employee Emp)
        {
            context.Employees.Add(Emp);
            context.SaveChanges();
        }

        public void DeleteEmployee(Employee Emp)
        {
            context?.Employees.Remove(Emp);
            context?.SaveChanges();
        }

        public void UpdateProfile(Employee Emp)
        {
            context?.Employees.Update(Emp);
            context?.SaveChanges();
        }

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
                .Include(e => e.DevTeam)
                    .ThenInclude(t =>  t.TeamManagers)
                        .ThenInclude(tm => tm.Game)
                            .ThenInclude(g => g.Assignments)
                .FirstOrDefault(e => e.Mail == employeeMail);
        }

        public IEnumerable<Employee>? GetTeamMembers(Employee emp)
        {
            return context.Employees
                .Where(e => e.DevTeamId == emp.DevTeamId && e.EmployeeId != emp.EmployeeId)
                .Include(e => e.Role)
                .ToList();
        }

        public Employee? GetEmployeeForUpdating(int employeeId)
        {
            return context.Employees
                .Include(e => e.Role)           // Include Role details
                .Include(e => e.DevTeam)        // Include DevTeam details
                .Include(e => e.ZipCodeNavigation) // Include City details
                .FirstOrDefault(e => e.EmployeeId == employeeId); // Filter by EmployeeId
        }

        public void UpdateEmployee(Employee employee)
        {
            // Attach the existing employee to the context and mark it as modified
            var existingEmployee = context.Employees
                .Include(e => e.Role)
                .Include(e => e.DevTeam)
                .Include(e => e.ZipCodeNavigation)
                .FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }
 
            // Update properties
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Address = employee.Address;
            existingEmployee.Mail = employee.Mail;
            existingEmployee.Password = employee.Password;
            existingEmployee.RoleId = employee.RoleId;
            existingEmployee.DevTeamId = employee.DevTeamId;

            // If ZipCode changes, update the ZipCodeNavigation
            if (existingEmployee.ZipCode != employee.ZipCode)
            {
                var city = context.Cities.FirstOrDefault(c => c.ZipCode == employee.ZipCode);
                if (city == null)
                {
                    throw new ArgumentException("Invalid Zip Code");
                }
                existingEmployee.ZipCode = city.ZipCode;
                existingEmployee.ZipCodeNavigation = city;
            }

            // Save changes to the database
            context.SaveChanges();
        }

        public void AssignEmpToTeam(Employee emp, DevTeam team)
        {
            var existingEmployee = context.Employees
                .Include(e => e.DevTeam)
                .FirstOrDefault(e => e.Mail == emp.Mail);

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            var existingTeam = context.DevTeams
                .Include(t => t.Employees)
                .FirstOrDefault(t => t.DevTeamId == team.DevTeamId);

            if (existingTeam == null)
            {
                throw new ArgumentException("DevTeam not found");
            }

            existingEmployee.DevTeamId = existingTeam.DevTeamId;
            context.SaveChanges();
        }

        public void UpdatePassword(Employee employee)
        {
            var existingEmployee = context.Employees
                .FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (existingEmployee != null)
            {
                existingEmployee.Password = employee.Password;
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Employee not found.");
            }
        }

        public IEnumerable<Employee> SearchEmployee(string searchString)
        {
           return context.Employees
               .Include(e => e.DevTeam)
               .Include(e => e.Role)
               .Include(e => e.ZipCodeNavigation)
               .Where(e =>
                   e.FirstName.Contains(searchString) ||
                   e.LastName.Contains(searchString) ||
                   e.Address.Contains(searchString) ||
                   e.Mail.Contains(searchString) ||
                   e.DevTeam.DevTeamId.ToString().Contains(searchString) ||
                   e.Role.RoleId.ToString().Contains(searchString))
               .ToList();
        }
    }
}
    