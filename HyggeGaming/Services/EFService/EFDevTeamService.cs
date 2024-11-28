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

        public IEnumerable<DevTeam> GetDevTeams()
        {
            throw new NotImplementedException();
        }

        //public List<DevT> GetTeamMembers(string teamName) //bruger teamName til at lave en liste med emplyees som har teamName til fælles...
        //{
        //    return context.DevTeams
        //        .Where(t => t.DevTname == teamName)
        //        .Include(t => t.DevT)
        //        .Select(t => t.DevT)
        //        .ToList();
        //}



    }
}
