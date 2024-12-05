using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Assignments
{
    public class AllAssignmentsModel : PageModel
    {
        IAssignmentService AssignmentService { get; set; }

        [BindProperty]
        public IEnumerable<Assignment> Assignment { get; set; }

        public AllAssignmentsModel(IAssignmentService service)
        {
            AssignmentService = service;
        }

        public void OnGet()
        {
            Assignment = AssignmentService.GetAllAssignments();
        }
    }
}
