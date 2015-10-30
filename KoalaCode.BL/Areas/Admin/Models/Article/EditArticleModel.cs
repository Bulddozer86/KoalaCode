using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Models.Article
{
    public class EditArticleModel
    {
        public int Id { get; set; }

        [StringLength(64)]
        [Required]
        public string Headline { get; set; }
        [Required]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}