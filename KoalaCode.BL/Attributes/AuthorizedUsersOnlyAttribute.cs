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
        public AuthorizedUsersOnlyAttribute()
        {
            
        }

        public List<string> RolesAccess { get; set; }

        public AuthorizedUsersOnlyAttribute(params string[] roles)
        {
            this.RolesAccess = roles.ToList();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var userInfo = UserData.GetUserInfo();
            if (userInfo == null || (RolesAccess != null && RolesAccess.Any() && !RolesAccess.Any(x => userInfo.Roles.Contains(x))))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Dashboard", action = "Login" }));   
            }
        }
    }
}