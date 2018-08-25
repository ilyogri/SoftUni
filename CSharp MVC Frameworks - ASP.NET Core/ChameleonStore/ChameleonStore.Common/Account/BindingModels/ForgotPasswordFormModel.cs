using System.ComponentModel.DataAnnotations;

namespace ChameleonStore.Web.Models.Account.BindingModels
{
    public class ForgotPasswordFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
