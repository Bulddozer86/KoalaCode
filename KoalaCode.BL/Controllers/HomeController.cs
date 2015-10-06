using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevOne.Security.Cryptography.BCrypt;
using KoalaCode.BL.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;
using Microsoft.Owin;
using Owin;

//using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Controllers
{
    public class HomeController : Controller
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

        // GET: Home
        public ActionResult Index()
        {
            var users = UnitOfWork.Users.GetAll();
            var model = new List<UserModel>();
            
            if (users != null)
            {
                model = users.Select(u => new UserModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Login = u.Login
                }).ToList();
            }
            //var test = BCryptHelper.HashPassword("test_pass", BCryptHelper.GenerateSalt(12));
            //var test1 = BCryptHelper.CheckPassword("test_pas", test);
            //var test2 = BCryptHelper.CheckPassword("test_pass", test);

            //return Content(String.Format("hash: {0}, wrong: {1}, correct: {2}", test, test1, test2));
            return View(model);
        }
    }
}