using System.Collections.Generic;
using System.Linq;
using KoalaCode.DAL.KoalaCodeDB.Entities;

namespace KoalaCode.DAL.KoalaCodeDB.Repositories
{
    public class ArticleRepository : RepositoryBase
    {
        public ArticleRepository(KoalaCode context)
            : base(context)
        {
        }

        public List<Article> GetAll()
        {
            return Context.Article.ToList();
        }

        public Article GetById(int id)
        {
            return Context.Article.SingleOrDefault(a => a.Id == id);
        }

        public List<Article> GetArticlesByUser(User user)
        {
            return Context.Article.Where(a => a.User.Id == user.Id).ToList();
        }

        public Article GetByUser(User u)
        {
            return null;
            //return Context.Article.Select(a => a.Users == u.Id).ToList();
        }
        
        public void Add(Article a)
        {
            Context.Article.Add(a);
        }
    }
}
