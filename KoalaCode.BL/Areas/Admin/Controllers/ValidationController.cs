using System.Web.Mvc;
using System.Web.UI;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
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

        public JsonResult IsEmailAlreadyInUse(string Email)
        {
            var user = UnitOfWork.Users.GetByEmail(Email);

            return user != null
                ? Json("Email is already in use.", JsonRequestBehavior.AllowGet)
                : Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsLoginAlreadyInUse(string Login)
        {
            var user = UnitOfWork.Users.GetByLogin(Login);

            return user != null
                ? Json("Login is already in use.", JsonRequestBehavior.AllowGet)
                : Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}