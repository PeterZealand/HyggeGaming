using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IAssignmentService
    {
        public List<string> Statuses();

        IEnumerable<Assignment> GetAllAssignments();

        public void CreateAssignment(Assignment assignment);

        public void UpdateAssignment(Assignment assignment);

        public IEnumerable<Assignment> SearchAssignment(string SearchString);

        public Assignment? GetAssignmentById(int id);

        //public bool AssignmentExists(int id);

        public void EditAssignment(Assignment assignment);
    }
}
