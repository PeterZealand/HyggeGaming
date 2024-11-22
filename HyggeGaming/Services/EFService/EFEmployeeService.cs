using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Services.EFService
{
    public class EFEmployeeService: IEmployeeService
    {
        private HGDBContext context;
        public EFEmployeeService(HGDBContext service)
        {
            context = service;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
