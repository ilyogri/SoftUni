using ChameleonStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Interfaces
{
    public interface IDropDownListable
    {
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();

        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();

        Task<IEnumerable<SelectListItem>> GetAvailableRolesAsync(IList<string> userRoles);
    }
}