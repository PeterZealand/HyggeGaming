using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Services.EFService
{
    public class EFAssignmentService : IAssignmentService
    {
        private HGDBContext context;
        public EFAssignmentService(HGDBContext service)
        {
            context = service;
        }

        public IEnumerable<Assignment> GetAssignment()
        {
            throw new NotImplementedException();
        }

        public void CreateAssignment(Assignment assignment)
        {
            context.Assignments.Add(assignment);
            context.SaveChanges();
        }

        public IEnumerable<Assignment> GetAllAssignments()
        {
            return context.Assignments
                .Include(a => a.Game)
                .ToList();
        }
    }
}
