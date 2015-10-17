using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class EditUserModel
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

        [MaxLength(64)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Karma { get; set; }

        public List<UserRoleListModel> Roles { get; set; }
    }

    public class UserRoleListModel
    {
        public int Id { get; set; }

        [Display(Name = "Role name")]
        public string Name { get; set; }

        public bool Selected { get; set; }
    }
}