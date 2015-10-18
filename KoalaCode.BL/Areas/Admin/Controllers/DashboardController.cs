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

        public ActionResult MainNavigation()
        {
            ViewBag.nav = new Dictionary<string, string>
            {    //TODO :: Controller - Action
                {"UserProfile", "Index"},
                {"Articles", "Index"},
                {"Dashboard", "Index"},
                {"User", "Index"},
                {"Role", "Index"}
            };

            return PartialView("_MainNavigation");
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