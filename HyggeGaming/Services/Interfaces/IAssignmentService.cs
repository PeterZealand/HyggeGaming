using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IAssignmentService
    {
        public List<string> Statuses();

        public IEnumerable<Assignment> GetAssignment();
        IEnumerable<Assignment> GetAllAssignments();

        public void CreateAssignment(Assignment assignment);
        public void UpdateAssignment(Assignment assignment);
    }
}
