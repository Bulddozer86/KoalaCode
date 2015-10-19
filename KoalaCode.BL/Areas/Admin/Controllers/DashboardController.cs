using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.BL.Attributes;
using KoalaCode.BL.Code;
using KoalaCode.BL.Code.BaseControllers;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.BL.Models.Navigation.Backend;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class DashboardController : BaseAuthRequired
    {
        // GET: Admin/Dashboard

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainNavigation(UrlHelper urlHelper)
        {
            var model = new List<BackendStaticNavigationModel>
            {
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Dashboard", Label = "Dashboard"}},
                {new BackendStaticNavigationModel { Action = "Index", Controller = "UserProfile", Label = "Profile"}},
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Articles", Label = "Articles"}},
                {new BackendStaticNavigationModel { Action = "Index", Controller = "User", Label = "Users"}},
                {new BackendStaticNavigationModel { Action = "Index", Controller = "Role", Label = "Roles"}},
            };

            return PartialView("_MainNavigation", model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            if (ModelState.IsValid)
            {
                var user = UnitOfWork.Users.GetByLogin(login);

                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, "There is wrong login or password. Try again.");
                    return View();
                }

                if (BCryptHelper.CheckPassword(password, user.Password))
                {
                    UserData.SetUserInfo(user);
                    return View("Index");
                }

                ModelState.AddModelError(String.Empty, "There is wrong login or password. Try again.");
                return View();
            }

            ModelState.AddModelError(String.Empty, "There is wrong login or password. Try again.");
            return View();
        }
    }
}