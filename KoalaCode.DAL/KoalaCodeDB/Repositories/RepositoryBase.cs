using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoalaCode.DAL.KoalaCodeDB.Repositories
{
    public class RepositoryBase
    {
        protected KoalaCode Context { get; set; }

         
        protected RepositoryBase(KoalaCode context)
        {
            Context = context;
        }

    }
}
