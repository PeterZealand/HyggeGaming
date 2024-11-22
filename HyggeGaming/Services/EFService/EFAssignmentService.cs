using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Services.EFService
{
    public class EFAssignmentService: IAssignmentService
    {
        private HGDBContext context;
        public EFAssignmentService(HGDBContext service)
        {
            context = service;
        }

        public IEnumerable<Assignment> GetAssignments()
        {
            throw new NotImplementedException();
        }
    }
}
