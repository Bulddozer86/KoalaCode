﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.DAL.KoalaCodeDB.Entities;
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
            string msg = "There is wrong login or password. Try again.";

            if (ModelState.IsValid)
            {
                var user = UnitOfWork.Users.GetByLogin(login);

                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, msg);
                    return View();
                }

                if (BCryptHelper.CheckPassword(password, user.Password))
                {
                    UserData.SetUserInfo(user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, msg);
                return View();
            }

            ModelState.AddModelError(String.Empty, msg);

            return View();
        }

        public ActionResult LogOut()
        {   
            UserData.ClearUserInfo();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(LoginUserInfo model)
        {
            //TODO :: I so lazy X_x
            var userByEmail = UnitOfWork.Users.GetByEmail(model.Email);
            var userByLogin = UnitOfWork.Users.GetByLogin(model.Login);

            if (userByEmail != null) ModelState.AddModelError("Email", string.Format("Email {0} already in use.", model.Email));
            if (userByLogin != null) ModelState.AddModelError("Login", string.Format("Email {0} already in use.", model.Login));

            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Login       = model.Login,
                Password    = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(12)),
                Email       = model.Email
            };

            UnitOfWork.Users.Add(user);
            UnitOfWork.SaveChanges();
            
            return View("LogIn");
        }
    }
}