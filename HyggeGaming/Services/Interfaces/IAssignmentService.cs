using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IAssignmentService
    {

        public IEnumerable<Assignment> GetAssignment();
        IEnumerable<Assignment> GetAllAssignments();

        public void CreateAssignment(Assignment assignment);

        public IEnumerable<Assignment> SearchAssignment(string SearchString);
    }
}
