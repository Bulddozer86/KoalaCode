using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KoalaCode.BL.Areas.Admin.Models.Article;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.BL.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;


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
            return View(GetListArticlesModel());
        }

        private List<ListArticlesModel> GetListArticlesModel()
        {
            var model = new List<ListArticlesModel>();
            var articles = UnitOfWork.Article.GetAll();

            if (articles == null) return model;

            model.AddRange(articles.Select(a => new ListArticlesModel
            {
                Id = a.Id,
                Headline = a.Headline,
                ShortDescription = a.ShortDescription,
                Description = a.Description,
                CreatedDate = a.CreatedDate
            }).OrderBy(a => a.CreatedDate));

            return model;
        }
    }
}