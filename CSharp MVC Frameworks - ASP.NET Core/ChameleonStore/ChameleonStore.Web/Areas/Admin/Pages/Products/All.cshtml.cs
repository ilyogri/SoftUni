using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChameleonStore.Common.Areas.Admin.Products.ViewModels;
using ChameleonStore.Common.Paging;
using ChameleonStore.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChameleonStore.Web.Areas.Admin.Pages.Products
{
    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class AllModel : PageModel
    {
        private readonly IAdminProductService products;

        public AllModel(IAdminProductService products)
        {
            this.products = products;
        }

        [BindProperty]
        public IEnumerable<AdminProductListingViewModel> Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Input = await this.products
                .GetAllAsync();

            return Page();
        }
    }
}