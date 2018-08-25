using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Products.BindingModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using ChameleonStore.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChameleonStore.Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
    {
        private readonly ChameleonStoreContext context;
        private readonly IMapper mapper;
        private readonly IAdminProductService products;
        private readonly IDropDownListable dropDownService;

        public ProductsController(
            ChameleonStoreContext context,
            IMapper mapper,
            IAdminProductService products,
            IDropDownListable dropDownService)
        {
            this.context = context;
            this.mapper = mapper;
            this.products = products;
            this.dropDownService = dropDownService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
            => View(new ProductFormModel
            {
                Brands = await this.dropDownService.GetBrandsAsync(),
                Categories = await this.dropDownService.GetCategoriesAsync()
            });

        [HttpPost]
        public async Task<IActionResult> Create(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.dropDownService.GetBrandsAsync();
                model.Categories = await this.dropDownService.GetCategoriesAsync();
                return View(model);
            }

            var id = await this.products.CreateAndGetIdAsync(model);

            TempData.AddSuccessMessage($"Product '{model.Name}' created successfully!");

            return RedirectToDetails(id);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await this.products.GetEditModelAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var isEdited = await this.products.EditAsync(id, model);

            if (!isEdited)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Product '{model.Name}' edited successfully!");

            return this.RedirectToPage("/Products/Details", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await this.products.GetEditModelAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var isDeleted = await this.products.DeleteAsync(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Product '{product.Name}' deleted successfully!");

            return RedirectToPage("/Products/All");
        }

        private IActionResult RedirectToDetails(int id)
        {
            return RedirectToPage("/Products/Details", new { id, area = "" });
        }
    }
}