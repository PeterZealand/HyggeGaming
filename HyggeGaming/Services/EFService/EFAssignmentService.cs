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
        public List<string> Statuses()
        {
            return new List<string>
            {
                "To Do",
                "In progress",
                "Pending review",
                "Complete",
                "On hold"
            };
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


        public void UpdateAssignment(Assignment assignment)
        {
            var existingAssignment = context.Assignments.FirstOrDefault(a => a.AssignmentId == assignment.AssignmentId);

            if (existingAssignment != null)
            {
                existingAssignment.Status = assignment.Status;
                context.SaveChanges();
            }            
        }

        public IEnumerable<Assignment> SearchAssignment(string SearchString)
        {
                  return context.Assignments
                 .Include(a => a.Game)
                 .Where(a =>
                    a.Description.Contains(SearchString) ||
                    a.AssignmentName.Contains(SearchString) ||
                    a.Status.Contains(SearchString) ||
                    a.Game.GameId.ToString().Contains(SearchString))
                 .ToList(); 
        }

        //forsøg med en int.parse - virkede ikke
        //public IEnumerable<Assignment> SearchAssignment(string SearchString)
        //{
        //    IEnumerable<Assignment>SearchedAssignments = context.Assignments.Where(a =>
        //         a.Description.Contains(SearchString) ||
        //         a.AssignmentName.Contains(SearchString) ||
        //         a.Status.Contains(SearchString));
        //    if (SearchedAssignments == null) 
        //            {
        //        int searchInt = Int32.Parse("SearchString");
        //        SearchedAssignments = context.Assignments.Where(a =>
        //         a.GameId.Equals(SearchString));  
        //          }

        //    return SearchedAssignments;
        //}

    }
}
