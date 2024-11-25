using HyggeGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HyggeGaming.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        private readonly HGDBContext dbContext;

        public string SuccessMsg = string.Empty;

        [BindProperty]
        public Employee Employee { get; set; }


        public AddEmployeeModel(HGDBContext context) => dbContext = context;
        public void OnGet(int employeeId)
        {
            Employee = new Employee();


            //return Page();
        }

        public IActionResult OnPost(int employeeId)
        {
            

            dbContext.Employees.Add(Employee);
            dbContext.SaveChanges();

            SuccessMsg = "You have added a new employee";
            return Page();
        }


        //private bool LinkBugToGame(int bugId, int gameId)
        //{
        //    var newBug = dbContext.Bugs
        //        .Include(x => x.Game)
        //        .FirstOrDefault(nb => nb.BugId == bugId && nb.GameId == gameId);

        //    if (newBug == null)
        //    {
        //        var newGameBug = new Bug
        //        {
        //            BugId = bugId,
        //            GameId = gameId
        //        };

        //        dbContext.Bugs.Add(newGameBug);
        //        //dbContext.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
    
}

