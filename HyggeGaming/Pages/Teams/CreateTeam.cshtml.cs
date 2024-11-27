using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HyggeGaming.Models;

namespace HyggeGaming.Pages.Teams
{
    public class CreateTeamModel : PageModel
    {
        private readonly HyggeGaming.Models.HGDBContext _context;

        public CreateTeamModel(HyggeGaming.Models.HGDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DevTeam DevTeam { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DevTeams.Add(DevTeam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
