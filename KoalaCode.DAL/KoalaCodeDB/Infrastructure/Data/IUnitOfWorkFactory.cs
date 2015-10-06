using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        UnitOfWork UnitOfWork { get; }
    }
}
