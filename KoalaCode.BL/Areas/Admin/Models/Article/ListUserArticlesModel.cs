using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoalaCode.BL.Areas.Admin.Models.Article
{
    public class ListUserArticlesModel
    {
        public int Id { get; set; }

        public string Headline { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime UpdatedDate { get; set; }
    }
}