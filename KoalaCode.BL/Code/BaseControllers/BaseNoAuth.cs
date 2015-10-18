using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.BL.Code.BaseControllers 
{
    public abstract class BaseNoAuth : System.Web.Mvc.Controller
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
    }
}