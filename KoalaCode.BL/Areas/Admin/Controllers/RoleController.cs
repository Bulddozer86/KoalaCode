using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoalaCode.BL.Areas.Admin.Models.Role;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Entities;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class RoleController : Controller
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
        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleList()
        {
            var model = GetRoleListModel();
            return PartialView("_RoleList", model);
        }

        public ActionResult Edit(int? id = null)
        {
            var role = id.HasValue ? UnitOfWork.Role.GetById(id.Value) : new Role();

            var model = new RoleListModel{Id = role.Id, Name = role.Name};

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RoleListModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var role = model.Id != 0 ? UnitOfWork.Role.GetById(model.Id) : new Role();
            
            role.Name = model.Name;
       

            if (model.Id == 0) UnitOfWork.Role.Add(role);

            UnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            return View("Index");
        }

        private List<RoleListModel> GetRoleListModel()
        {
            var roles = UnitOfWork.Role.GetAll();

            return roles == null ? new List<RoleListModel>() : roles.Select(r => new RoleListModel
            {
                Id = r.Id,
                Name = r.Name
            }).OrderBy(x => x.Id).ToList();
        }
    }
}