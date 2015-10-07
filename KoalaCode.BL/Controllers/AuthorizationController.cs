using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Controllers
{
    public class AuthorizationController : Controller
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
        // GET: Authorization
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string login, string password)
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
                    return RedirectToAction("Index","Home");
                }

                ModelState.AddModelError(String.Empty, "There is wrong login or password. Try again.");
                return View();
            }

            ModelState.AddModelError(String.Empty, "There is wrong login or password. Try again.");

            return View();
        }

        public ActionResult LogOut()
        {
            return View();
        }
    }
}