using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KoalaCode.DAL.KoalaCodeDB.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Headline { get; set; }

        [Required, AllowHtml]
        public string ShortDescription { get; set; }
        [Required, AllowHtml]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        public User User { get; set; }
    }
}
