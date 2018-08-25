using ChameleonStore.Common.Areas.Admin.Users.BindingModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Interfaces
{
    public interface IRoleService
    {
        Task<AddToRoleFormModel> GetByUserIdAsync(string userId, IList<string> currentUserRoles);

        Task<IdentityRole> GetByIdAsync(string id);
    }
}
