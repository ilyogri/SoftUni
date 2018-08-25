using System.ComponentModel.DataAnnotations;
using ChameleonStore.Data;

namespace ChameleonStore.Web.Areas.Identity.Models.Account
{
    public class RegisterFormModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(DataConstants.UsernameMaxLength, MinimumLength = DataConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(DataConstants.PasswordMaxLength, MinimumLength = DataConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
