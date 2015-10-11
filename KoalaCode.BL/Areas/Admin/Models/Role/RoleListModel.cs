using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KoalaCode.BL.Areas.Admin.Models.Role
{
    public class RoleListModel
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        [Display(Name = "Role name")]
        public string Name { get; set; }
    }
}