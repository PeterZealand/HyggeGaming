using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Assignments
{
    public class EditAssignmentModel : PageModel
    {
        private readonly IAssignmentService AssignmentService;

        private readonly IGameService GameService;

        [BindProperty]
        public Assignment Assignment { get; set; }
        public List<string> StatusOptions { get; set; }
        public EditAssignmentModel(IAssignmentService assignmentService, IGameService gameService)
        {
            AssignmentService = assignmentService;
            GameService = gameService;
        }

        

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = AssignmentService.GetAssignmentById(id.Value);
            if (assignment == null)
            {
                return NotFound();
            }

            Assignment = assignment;
            ViewData["GameId"] = new SelectList(GameService.GetGames(), "GameId", "GameId");
            StatusOptions = AssignmentService.Statuses();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ViewData["GameId"] = new SelectList(GameService.GetGames(), "GameId", "GameId");
                StatusOptions = AssignmentService.Statuses();
                return Page();
            }

            AssignmentService.EditAssignment(Assignment);
            return RedirectToPage("/Assignments/AllAssignments");
        }
    }
}
