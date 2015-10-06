using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class EditUserModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(64)]
        [Remote("IsLoginAlreadyInUse", "Validation")]
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

        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Karma { get; set; }
        
        //public List<Role> Roles { get; set; }
    }
}