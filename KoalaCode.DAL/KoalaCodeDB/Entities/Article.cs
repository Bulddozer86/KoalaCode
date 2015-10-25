using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoalaCode.DAL.KoalaCodeDB.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Headline { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? DeletedById { get; set; }
        public virtual Article DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int? UpdatedById { get; set; }
        public virtual Article UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        
        public int? BannedById { get; set; }
        public virtual Article BannedBy { get; set; }
        public DateTime? BannedDate { get; set; }

        public int? BannedFor { get; set; }
        public virtual ICollection<User> Users { get; set; }

        [StringLength(1024)]
        public string BanReason { get; set; }

        [ForeignKey("DeletedById")]
        public virtual ICollection<User> DeletedUsers { get; set; }

        [ForeignKey("BannedById")]
        public virtual ICollection<User> BannedUsers { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual ICollection<User> UpdatedUsers { get; set; }

        public Article()
        {
            Users = new HashSet<User>();
            DeletedUsers = new HashSet<User>();
            BannedUsers = new HashSet<User>();
            UpdatedUsers = new HashSet<User>();
        }
    }

    internal class ArticleConfiguration : EntityTypeConfiguration<User>
    {
        public ArticleConfiguration()
        {
        }
    }
}
