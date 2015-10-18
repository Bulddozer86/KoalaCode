using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.BL.Attributes;
using KoalaCode.BL.Code;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private UnitOfWork _unitOfWork;
        protected UnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWorkFactory>().UnitOfWork;
                }
                return _unitOfWork;
            }
        }
        // GET: Admin/Dashboard
         [AuthorizedUsersOnly(Constans.Roles.Admin, Constans.Roles.Moderator)]
        public ActionResult Index()
        {
            List<string> mainNavigation = new List<string>
            {
                Url.Action("Index", "Dashboard"),
                Url.Action("Index", "User"),
                Url.Action("Index", "Role"),
            };

            return View(mainNavigation);
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