using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class LoginUserInfo
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public DateTime? DeletedDate { get; set; }

        public DateTime? BannedDate { get; set; }
    }
}