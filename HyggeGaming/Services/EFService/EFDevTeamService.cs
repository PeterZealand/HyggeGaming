using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFDevTeamService: IDevTeamService
    {
        private HGDBContext context;
        public EFDevTeamService(HGDBContext service)
        {
            context = service;
        }

        public void CreateDevTeam(DevTeam team)
        {
            context.DevTeams.Add(team);
            context.SaveChanges();
            //return team;
        }

       //public List<Employee> GetTeamMembers(string teamName) //bruger teamName til at lave en liste med emplyees som har teamName til fælles...
        //{
        //    return context.DevTeams
        //        .Where(t => t.DevTname == teamName)
        //        .Include(t => t.Employee)
        //        .Select(t => t.Employee)
        //        .ToList();
        //}

        public IEnumerable<DevTeam> GetDevTeams()
        {
            return context.DevTeams
                .Include(t => t.Employees);
                
        }
    }
}
