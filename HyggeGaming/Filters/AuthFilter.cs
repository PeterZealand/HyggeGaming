using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HyggeGaming.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if session exists
            var userSession = context.HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userSession))
            {
                // Redirect to login if session is missing
                context.Result = new RedirectToPageResult("/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}
