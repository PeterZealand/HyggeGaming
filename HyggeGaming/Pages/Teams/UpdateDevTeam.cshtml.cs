using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HyggeGaming.Pages.Teams
{
    //public class UpdateTeamModel : PageModel
    //{
    //    private readonly HGDBContext _context;
    //    public UpdateTeamModel(HGDBContext context)
    //    {
    //        _context = context;
    //    }

    //    private readonly IDevTeamService devTeamService;

    //    [BindProperty]
    //    public DevTeam DevT { get; set; }


    //    public async Task<IActionResult> OnGetAsync(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var employee = await _context.DevTeams.FirstOrDefaultAsync(m => m.DevTeamId == id);

    //        if (employee == null)
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            DevT = employee;
    //        }
    //        return Page();

    //    }

    //    public IActionResult OnPost()
    //    {


    //        return RedirectToPage("/Teams/ManageDevTeams");
    //    }
    //}
    public class UpdateDevTeamModel : PageModel
    {
        private readonly HGDBContext _context;

        public UpdateDevTeamModel(HGDBContext context)
        {
            _context = context;
            //IDevTeamService service
            //DevTeamService = service;
        }

        private readonly IDevTeamService devTeamService;
 //{ get; set; }

        [BindProperty]
        public DevTeam DevT { get; set; }
        //public DevTeam? DevT { get; set; }


        //public IEnumerable<DevTeam> DevTeams { get; set; }
        //public IEnumerable<Employee>? Employees { get; private set; }

       

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Hent DevTeam fra databasen baseret på ID
            var devT = await _context.DevTeams.FirstOrDefaultAsync(m => m.DevTeamId == id);
     
            if (devT == null)
            {
                return NotFound();
            }
            else
            {
                DevT = devT;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Opdater DevTeam i databasen
            _context.Attach(DevT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevTeamExists(DevT.DevTeamId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Teams/ManageDevTeams");
        }

        private bool DevTeamExists(int id)
        {
            return _context.DevTeams.Any(e => e.DevTeamId == id);
        }
    }
}



