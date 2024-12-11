using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IDevTeamService
    {
        public IEnumerable<DevTeam> GetDevTeams();
        public void CreateDevTeam(DevTeam devT);
        public void UpdateDevTeam(DevTeam updatedevT);
        public IEnumerable<DevTeam> TeamSearch(string SearchString);

    }
}
