using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KoalaCode.DAL.KoalaCodeDB.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required, StringLength(255)]
        public string Login { get; set; }

        [Required, StringLength(255)]
        public string Password { get; set; }

        [Index(IsUnique = true)]
        [Required, StringLength(255)]
        public string Email { get; set; }

        [StringLength(64)]
        public string FirstName { get; set; }

        [StringLength(64)]
        public string LastName { get; set; }

        public string Description { get; set; }

        public int Karma { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? DeletedById { get; set; }
        public virtual User DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int? UpdatedById { get; set; }
        public virtual User UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int? BannedById { get; set; }
        public virtual User BannedBy { get; set; }
        public DateTime? BannedDate { get; set; }

        public int? BannedFor { get; set; }

        [StringLength(1024)]
        public string BanReason { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        [ForeignKey("DeletedById")]
        public virtual ICollection<User> DeletedUsers { get; set; }

        [ForeignKey("BannedById")]
        public virtual ICollection<User> BannedUsers { get; set; }

        [ForeignKey("UpdatedById")]
        public virtual ICollection<User> UpdatedUsers { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
            DeletedUsers = new HashSet<User>();
            BannedUsers = new HashSet<User>();
            UpdatedUsers = new HashSet<User>();
        }
    }

    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
        }
    }
}
