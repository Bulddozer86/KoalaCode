using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoalaCode.DAL.KoalaCodeDB.Entities;
using KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data;

namespace KoalaCode.DAL.KoalaCodeDB.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(KoalaCode context) : base(context)
        {
        }

        public List<User> GetAll()
        {
            return Context.User.ToList();
        }

        public User GetById(int id)
        {
           return Context.User.SingleOrDefault(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            return Context.User.SingleOrDefault(u => u.Email == email);
        }

        public User GetByLogin(string login)
        {
            return Context.User.SingleOrDefault(u => u.Login == login);
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            return Context.User.SingleOrDefault(u => u.Login == login && u.Password == password);
        }

        public void Add(User user)
        {
            Context.User.Add(user);
        }
    }
}
