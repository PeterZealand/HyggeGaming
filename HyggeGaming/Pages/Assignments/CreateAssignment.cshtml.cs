using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Pages.Assignments
{
    public class CreateAssignmentModel : PageModel
    {
        private readonly IAssignmentService AssignmentService;
        private readonly IGameService GameService; // Assuming a service for fetching games.

        [BindProperty]
        public Assignment Assignment { get; set; }

        public CreateAssignmentModel(IAssignmentService assignmentService, IGameService gameService)
        {
            AssignmentService = assignmentService;
            GameService = gameService;
        }

        public IActionResult OnGet()
        {
            // Fetching games via the service and preparing for the dropdown.
            ViewData["GameId"] = new SelectList(GameService.GetGames(), "GameId", "GameId");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ViewData["GameId"] = new SelectList(GameService.GetGames(), "GameId", "GameId");
                return Page();
            }

            // Add assignment via the service.
            AssignmentService.CreateAssignment(Assignment);

            return RedirectToPage("/Assignments/AllAssignments");
        }
    }
}
