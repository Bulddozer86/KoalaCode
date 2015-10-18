using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class RegisterUserModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(64)]
        [Remote("IsLoginAlreadyInUse", "Validation", AdditionalFields = "Id")]
        public string Login { get; set; }

        [Remote("IsPasswordRequired", "Validation", AdditionalFields = "Id")]
        [MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Remote("IsEmailAlreadyInUse", "Validation", AdditionalFields = "Id")]
        public string Email { get; set; }
    }


}