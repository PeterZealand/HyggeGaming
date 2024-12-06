using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IDevTeamService
    {
        public IEnumerable<DevTeam> GetDevTeams();
        public IEnumerable<DevTeam> ManageDevTeams();

        //public List<DevT> GetTeamMembers(string teamName);

        public void CreateDevTeam(DevTeam devT);
        public void UpdateDevTeam(DevTeam updatedevT);

    }
}
