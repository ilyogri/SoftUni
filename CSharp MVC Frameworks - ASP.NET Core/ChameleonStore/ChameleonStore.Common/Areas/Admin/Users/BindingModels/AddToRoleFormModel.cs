using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChameleonStore.Common.Areas.Admin.Users.BindingModels
{
    public class AddToRoleFormModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public string RoleId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
