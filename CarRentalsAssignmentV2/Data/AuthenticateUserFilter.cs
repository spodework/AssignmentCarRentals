using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace CarRentalsAssignmentV2.Data
{
    public class AuthenticateUserFilter : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var role = filterContext.HttpContext.Session.GetString("UserRole");

            
            if (role != "Admin")
            {
                filterContext.Result = new RedirectToActionResult("Index", "Home",null);
                return;
            }

            base.OnActionExecuting(filterContext);

        }

    }
}
