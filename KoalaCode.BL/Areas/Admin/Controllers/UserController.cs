using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.BL.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Entities;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class UserController : Controller
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            var model = GetUserListModel();
            return PartialView("_UserList", model);
        }

        public ActionResult Edit(int? id = null)
        {
            var user = id.HasValue ? UnitOfWork.Users.GetById(id.Value) : new User();

            var model = new EditUserModel
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
                Karma = user.Karma
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            var userByEmail = UnitOfWork.Users.GetByEmail(model.Email);
            var userByLogin = UnitOfWork.Users.GetByLogin(model.Login);

            if (userByEmail != null) ModelState.AddModelError("Email", string.Format("Email {0} already in use.", model.Email));
            if (userByLogin != null) ModelState.AddModelError("Login", string.Format("Email {0} already in use.", model.Login));

            if (!ModelState.IsValid) return View(model);
            
            var user = model.Id != 0 ? UnitOfWork.Users.GetById(model.Id) : new User
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            user.Login = model.Login;
            user.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(12));
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Description = model.Description;
            user.Karma = model.Karma;

            if(model.Id == 0) UnitOfWork.Users.Add(user);

            UnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var user = UnitOfWork.Users.GetById(id);
            user.DeletedById = id; //TODO: fix me after authorization
            user.DeletedDate = DateTime.Now;
            UnitOfWork.SaveChanges();

            var model = GetUserListModel();
            return PartialView("_UserList", model);
        }

        public ActionResult Restore(int id)
        {
            var user = UnitOfWork.Users.GetById(id);
            user.DeletedById = null;
            user.DeletedDate = null;
            UnitOfWork.SaveChanges();

            var model = GetUserListModel();
            return PartialView("_UserList", model);
        }

        private List<UserListItemModel> GetUserListModel()
        {
            var users = UnitOfWork.Users.GetAll();
            var model = new List<UserListItemModel>();

            if (users == null) return model;

            return users.Select(u => new UserListItemModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Login = u.Login,
                Email = u.Email,
                IsDeleted = u.DeletedDate != null
            })
            .OrderBy(x => x.IsDeleted).ThenBy(x => x.Email)
            .ToList();
        }

        
    }
}