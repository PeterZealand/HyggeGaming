using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HyggeGaming.Models;

namespace HyggeGaming.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly HyggeGaming.Models.HGDBContext _context;

        public IndexModel(HyggeGaming.Models.HGDBContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Assignment = await _context.Assignments
                .Include(a => a.Game).ToListAsync();
        }
    }
}
