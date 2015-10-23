using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using KoalaCode.BL.Attributes;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.BL.Models.Navigation.Backend;


namespace KoalaCode.BL.Code.Infrastructure.Navigation
{
    public class BackendNavigation
    {
        public object GetBackendNavigation()
        {
            var user = UserData.GetUserInfo();
            var menuItems = UserNavigation();

            if (user.Roles.Any(x => user.Roles.Contains(Constans.Roles.Moderator))
                || user.Roles.Any(x => user.Roles.Contains(Constans.Roles.Admin)))
            {
                menuItems = menuItems.Concat(ModeratorNavigation());
            }

            if (user.Roles.Any(x => user.Roles.Contains(Constans.Roles.Admin)))
            {
                menuItems = menuItems.Concat(AdminNavigation());
            }

            return menuItems.ToList();
        }

        
        protected IEnumerable<BackendStaticNavigationModel> AdminNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Role", Label = "Roles"}}
            };
        }
        
        protected IEnumerable<BackendStaticNavigationModel> ModeratorNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "User", Label = "Users"}}
            };
        }
        
        protected IEnumerable<BackendStaticNavigationModel> UserNavigation()
        {
            return new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Dashboard", Label = "Dashboard"}},
               {new BackendStaticNavigationModel { Action = "Index", Controller = "UserProfile", Label = "Profile"}},
               {new BackendStaticNavigationModel { Action = "Index", Controller = "Articles", Label = "Articles"}}
            };
        }
    }
}