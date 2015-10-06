using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View();
        }
    }
}