using AutoMapper;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Implementations
{
    public class DropDownListService : BaseEFService, IDropDownListable
    {
        public DropDownListService(
            ChameleonStoreContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
            => await this.Context
                .Brands
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToListAsync();

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
            => await this.Context
                .Categories
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToListAsync();

        public async Task<IEnumerable<SelectListItem>> GetAvailableRolesAsync(IList<string> userRoles)
             => await this.Context
                .Roles
                .Where(r => !userRoles.Contains(r.Name))
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToListAsync();
    }
}
