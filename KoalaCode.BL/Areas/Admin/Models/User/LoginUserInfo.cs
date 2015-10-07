using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class LoginUserInfo
    {
        [Required]
        [MinLength(6), MaxLength(64)]
        public string Login { get; set; }

        [Required]
        [MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Remote("IsEmailAlreadyInUse", "Validation")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}