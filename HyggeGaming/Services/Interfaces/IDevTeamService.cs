using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IDevTeamService
    {
        public IEnumerable<DevTeam> GetDevTeams();

        public void CreateDevTeam(DevTeam team);
    }
}
