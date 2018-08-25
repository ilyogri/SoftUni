using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Users.BindingModels;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Implementations
{
    public class RoleService : BaseEFService, IRoleService
    {
        private readonly IDropDownListable dropDownService;

        public RoleService(
            ChameleonStoreContext context,
            IMapper mapper,
            IDropDownListable dropDownService)
            : base(context, mapper)
        {
            this.dropDownService = dropDownService;
        }

        public async Task<AddToRoleFormModel> GetByUserIdAsync(string userId, IList<string> currentUserRoles)
        {
            var roles = await this.dropDownService
                .GetAvailableRolesAsync(currentUserRoles);

            var model = new AddToRoleFormModel
            {
                Id = userId,
                Roles = roles
            };

            return model;
        }

        public async Task<IdentityRole> GetByIdAsync(string id)
            => await this.Context
                .Roles
                .FindAsync(id);
    }
}
