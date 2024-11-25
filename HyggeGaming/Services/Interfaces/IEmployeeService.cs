using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees();

        public Employee? CheckCredentials();
    }   
}
