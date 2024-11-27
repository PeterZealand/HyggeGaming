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
            return context.DevTeams
                .Include(t => t.Employees)
                /*.ToList()*/;
                
        }
    }
}
