using HyggeGaming.Models;

namespace HyggeGaming.Services.Interfaces
{
    public interface IAssignmentService
    {
        public IEnumerable<Assignment> GetAssignments();
    }
}
