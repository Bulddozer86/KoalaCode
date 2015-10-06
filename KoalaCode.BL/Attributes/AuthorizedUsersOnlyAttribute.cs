using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KoalaCode.BL.Infrastructure.Authorize;

namespace KoalaCode.BL.Attributes
{
    public class AuthorizedUsersOnlyAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (UserData.GetUserInfo() != null) return;
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Dashboard", action = "Login" }));
        }
    }
}