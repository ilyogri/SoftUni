using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Products.BindingModels;
using ChameleonStore.Common.Areas.Admin.Products.ViewModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Implementations
{
    public class AdminProductService : BaseEFService, IAdminProductService
    {
        private readonly IProductService products;
        private readonly IDropDownListable dropDownService;

        public AdminProductService(
            ChameleonStoreContext context,
            IMapper mapper,
            IProductService products,
            IDropDownListable dropDownService)
            : base(context, mapper)
        {
            this.products = products;
            this.dropDownService = dropDownService;
        }

        public async Task<IEnumerable<AdminProductListingViewModel>> GetAllAsync()
        {
            var products = await this.Context
                .Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

            var modelProducts = this.Mapper.Map<IEnumerable<AdminProductListingViewModel>>(products);

            return modelProducts;
        }

        public async Task<int> CreateAndGetIdAsync(ProductFormModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Condition = model.Condition,
                ImageURL = model.ImageUrl
            };

            await this.Context
               .Products
               .AddAsync(product);

            await this.Context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<ProductFormModel> GetEditModelAsync(int id)
        {
            var product = await this.products.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            var model = new ProductFormModel
            {
                Name = product.Name,
                Condition = product.Condition,
                Price = product.Price,
                ImageUrl = product.ImageURL,
                Description = product.Description,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                Brands = await this.dropDownService.GetBrandsAsync(),
                Categories = await this.dropDownService.GetCategoriesAsync()
            };

            return model;
        }

        public async Task<bool> EditAsync(int id, ProductFormModel model)
        {
            var product = await this.products.GetByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            product.Name = model.Name;
            product.ImageURL = model.ImageUrl;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.Price = model.Price;
            product.Description = model.Description;

            await this.Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await this.products.GetByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            this.Context.Products.Remove(product);
            await this.Context.SaveChangesAsync();
            return true;
        }
    }
}
