using System.Data.Entity.ModelConfiguration.Conventions;
using KoalaCode.DAL.KoalaCodeDB.Entities;

namespace KoalaCode.DAL.KoalaCodeDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KoalaCode : DbContext
    {
        public KoalaCode()
            : base("name=KoalaCode")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Article> Article { get; set; }

    }
}
