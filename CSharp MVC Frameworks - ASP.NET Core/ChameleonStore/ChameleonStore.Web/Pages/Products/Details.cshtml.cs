using System.Linq;
using System.Threading.Tasks;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using ChameleonStore.Models.Enums;
using ChameleonStore.Web.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ChameleonStore.Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService products;

        public DetailsModel(IProductService products)
        {
            this.products = products;
        }

        [BindProperty]
        public ProductDetailsViewModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var model = await this.products.GetDetailsAsync(id);
            
            if(model == null)
            {
                return NotFound();
            }

            var parsedEnum = (ProductCondition)Enum.Parse(typeof(ProductCondition), model.Condition);
            var friendlyConditionName = parsedEnum.GetAttribute<DisplayAttribute>().Name;
            model.Condition = friendlyConditionName;
            this.Input = model;

            return Page();
        }
    }
}