using HyggeGaming.Models;
using System.Collections;

namespace HyggeGaming.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<DevTeam> GetDevTeams();

        public IEnumerable<Role> GetRoles();

        public IEnumerable<City> GetCities();

        public IEnumerable<Employee> GetEmployees();
        
        public bool CheckCredentials(Employee employee);

        public Employee? GetEmployee(string loggedInEmployee);
       
        public IEnumerable<Employee>? GetTeamMembers(Employee emp);

        public void AddEmployee(Employee addEmp);

        public void DeleteEmployee(Employee deleteEmp);

        public Employee? GetEmployeeForUpdating(int employeeId);

        public void AssignEmpToTeam(Employee emp, DevTeam team);

        void UpdateEmployee(Employee employee);
        void UpdatePassword(Employee employee);
        public IEnumerable<Employee> SearchEmployee(string SearchString);
    }
}
