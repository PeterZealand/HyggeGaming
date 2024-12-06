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
        public IEnumerable<Employee> GetEmployee(Employee Emp);

        //public Employee CheckCredentials(Employee employee);
        public bool CheckCredentials(Employee employee);

        public Employee? GetEmployee(string loggedInEmployee);
       

        public IEnumerable<Employee>? GetTeamMembers(Employee emp);

        public void AddEmployee(Employee addEmp);

        public void DeleteEmployee(Employee deleteEmp);

        public Employee? GetEmployeeForUpdating(int employeeId);

        void UpdateEmployee(Employee employee);

    }
}
