using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HyggeGaming.Models;

namespace HyggeGaming.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly HyggeGaming.Models.HGDBContext _context;

        public CreateModel(HyggeGaming.Models.HGDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assignments.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
