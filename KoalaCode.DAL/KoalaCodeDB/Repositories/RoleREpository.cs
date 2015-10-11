using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoalaCode.DAL.KoalaCodeDB.Entities;

namespace KoalaCode.DAL.KoalaCodeDB.Repositories
{
    public class RoleRepository : RepositoryBase
    {
        public RoleRepository(KoalaCode context) : base(context)
        {
        }
        public List<Role> GetAll()
        {
            return Context.Role.ToList();
        }

        public Role GetById(int id)
        {
            return Context.Role.SingleOrDefault(u => u.Id == id);
        }

        public void Add(Role role)
        {
            Context.Role.Add(role);
        }
    }
}
