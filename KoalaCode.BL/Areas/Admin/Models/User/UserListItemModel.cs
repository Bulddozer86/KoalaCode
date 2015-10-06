using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class UserListItemModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
    }
}