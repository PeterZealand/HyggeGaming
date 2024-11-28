﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;

namespace HyggeGaming.Pages.Assignments
{
    public class DeleteModel : PageModel
    {
        private readonly HyggeGaming.Models.HGDBContext _context;

        public DeleteModel(HyggeGaming.Models.HGDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == id);

            if (assignment == null)
            {
                return NotFound();
            }
            else
            {
                Assignment = assignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                Assignment = assignment;
                _context.Assignments.Remove(Assignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
