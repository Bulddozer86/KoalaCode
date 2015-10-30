using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KoalaCode.DAL.KoalaCodeDB.Repositories;

namespace KoalaCode.DAL.KoalaCodeDB.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly KoalaCode _context;
        public UnitOfWork()
        {
            _context = new KoalaCode();
        }
        public UserRepository Users { get { return new UserRepository(_context); } }
        public RoleRepository Role { get { return new RoleRepository(_context);} }
        public ArticleRepository Article { get { return new ArticleRepository(_context); } }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
