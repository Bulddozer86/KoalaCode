using System;
using System.Web.Mvc;
using KoalaCode.BL.Areas.Admin.Models.Article;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.BL.Code.BaseControllers;
using KoalaCode.BL.Infrastructure.Authorize;
using KoalaCode.DAL.KoalaCodeDB.Entities;

namespace KoalaCode.BL.Areas.Admin.Controllers
{
    public class ArticlesController : BaseAuthRequired
    {
        // GET: Admin/Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int? id = null)
        {
            var article = id.HasValue ? UnitOfWork.Article.GetById(id.Value) : new Article();
            var user = UnitOfWork.Users.GetByLogin(UserData.GetUserInfo().Login);

            var model = new EditArticleModel
            {
                Id = article.Id,
                Headline = article.Headline,
                ShortDescription = article.ShortDescription,
                Description = article.Description,
                UserId = user.Id
            };

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(EditArticleModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var article = model.Id != 0 ? UnitOfWork.Article.GetById(model.Id) : new Article
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            article.Headline = model.Headline;
            article.ShortDescription = model.ShortDescription;
            article.Description = model.ShortDescription;
            //TODO::fix it
            article.User = UnitOfWork.Users.GetByLogin(UserData.GetUserInfo().Login);

            if (model.Id == 0) UnitOfWork.Article.Add(article);

            UnitOfWork.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}