using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using KoalaCode.BL.Attributes;
using KoalaCode.BL.Models.Navigation.Backend;


namespace KoalaCode.BL.Code.Infrastructure.Navigation
{
    public class BackendNavigation
    {
        public object GetBackendNavigation()
        {
            return new List<object>
            {
                AdminAndModeratorNavigation(),
                AdminNavigation(),
                UserNavigation()
            };
        }

        [AuthorizedUsersOnly(Constans.Roles.Admin)]
        protected List<BackendStaticNavigationModel> AdminNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Role", Label = "Roles"}}
            };
        }

        [AuthorizedUsersOnly(Constans.Roles.Admin, Constans.Roles.Moderator)]
        protected List<BackendStaticNavigationModel> AdminAndModeratorNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Dashboard", Label = "Dashboard"}},
                {new BackendStaticNavigationModel { Action = "Index", Controller = "User", Label = "Users"}}
            };
        }

        [AuthorizedUsersOnly(Constans.Roles.Admin, Constans.Roles.Moderator, Constans.Roles.User)]
        protected List<BackendStaticNavigationModel> UserNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
               {new BackendStaticNavigationModel { Action = "Index", Controller = "UserProfile", Label = "Profile"}},
               {new BackendStaticNavigationModel { Action = "Index", Controller = "Articles", Label = "Articles"}}
            };
        }
    }
}