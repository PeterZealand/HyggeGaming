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

        public IEnumerable<Assignment> SearchAssignment(string SearchString)
        {
            IEnumerable<Assignment>SearchedAssignments = context.Assignments.Where(a =>
                 a.Description.Contains(SearchString) ||
                 a.AssignmentName.Contains(SearchString) ||
                 a.Status.Contains(SearchString));
            if (SearchedAssignments == null) 
                    {
                int searchInt = Int32.Parse("SearchString");
                SearchedAssignments = context.Assignments.Where(a =>
                 a.GameId.Equals(SearchString));  
                  }

            return SearchedAssignments;
        }
    }
}
