using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IDevTeamService
    {
        public IEnumerable<DevTeam> GetDevTeams();

        //public List<DevT> GetTeamMembers(string teamName);

        public void CreateDevTeam(DevTeam team);

    }
}
