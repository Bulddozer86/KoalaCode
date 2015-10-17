using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Areas.Admin.Models.Role;
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

        public ActionResult ChangePassword(int id)
        {
            var user = UnitOfWork.Users.GetById(id);

            if (user == null) 
                throw new Exception("User not found. ID: " + id);

            return PartialView("_ChangePassword", new ChangePasswordModel { Id = id });
        }

        [HttpPost]
        public void ChangePassword(ChangePasswordModel model)
        {
            var user = UnitOfWork.Users.GetById(model.Id);

            if (user == null)
                throw new Exception("User not found. ID: " + model.Id);

            user.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(12));
            UnitOfWork.SaveChanges();
        }

        public ActionResult Edit(int? id = null)
        {
            var user = id.HasValue ? UnitOfWork.Users.GetById(id.Value) : new User();
            var roles = GetRoleListModel(user.Id);

            var model = new EditUserModel
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
                Karma = user.Karma,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Password) && model.Id == 0) ModelState.AddModelError("Password", "Password is required.");

            var userByEmail = UnitOfWork.Users.GetByEmail(model.Email);
            var userByLogin = UnitOfWork.Users.GetByLogin(model.Login);

            if (userByEmail != null && userByEmail.Id != model.Id) ModelState.AddModelError("Email", string.Format("Email {0} already in use.", model.Email));
            if (userByLogin != null && userByLogin.Id != model.Id) ModelState.AddModelError("Login", string.Format("Login {0} already in use.", model.Login));

            if (!ModelState.IsValid) return View(model);
            
            var user = model.Id != 0 ? UnitOfWork.Users.GetById(model.Id) : new User
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            user.Login = model.Login;
            
            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                user.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(12));    
            }
            
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Description = model.Description;
            user.Karma = model.Karma;

            var roles = UnitOfWork.Users.GetAllRoles();
            user.Roles.Clear();
            user.Roles = roles.Where(x => model.Roles.Any(r => r.Selected && r.Id == x.Id)).ToList();

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

        private List<UserRoleListModel> GetRoleListModel(int userId)
        {
            var roles = UnitOfWork.Role.GetAll();

            return roles == null ? new List<UserRoleListModel>() : roles.Select(r => new UserRoleListModel
            {
                Id = r.Id,
                Name = r.Name,
                Selected = r.Users.Any(x => x.Id == userId)
            }).OrderBy(x => x.Id).ToList();
        }
    }
}