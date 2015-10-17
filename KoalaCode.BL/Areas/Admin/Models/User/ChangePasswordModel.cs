using System.ComponentModel.DataAnnotations;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}