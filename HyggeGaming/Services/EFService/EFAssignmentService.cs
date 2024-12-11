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

        public Assignment? GetAssignmentById(int id)
        {
            return context.Assignments
                .Include(a => a.Game)
                .FirstOrDefault(a => a.AssignmentId == id);
        }

        public bool AssignmentExists(int id)
        {
            return context.Assignments.Any(a => a.AssignmentId == id);
        }

        public void EditAssignment(Assignment assignment)
        {
            var existingAssignment = GetAssignmentById(assignment.AssignmentId);

            if (existingAssignment == null)
            {
                throw new ArgumentException("Assignment not found");
            }

            // Update properties
            existingAssignment.AssignmentName = assignment.AssignmentName;
            existingAssignment.Description = assignment.Description;
            existingAssignment.Status = assignment.Status;
            existingAssignment.GameId = assignment.GameId;

            context.SaveChanges();
        }
    }
}
