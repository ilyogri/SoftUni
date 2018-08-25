using AutoMapper;
using ChameleonStore.Common.Home.ViewModels;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Common.ShoppingCart.ViewModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using ChameleonStore.Web;

namespace ChameleonStore.Services.Implementations
{
    public class ProductService : BaseEFService, IProductService
    {
        public ProductService(
            ChameleonStoreContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public int Total() => this.Context.Products.Count();

        public async Task<Product> GetByIdAsync(int id)
        {
            return await this.Context
                .Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateViews(Product product)
        {
            product.Views++;
            await this.Context.SaveChangesAsync();
        }

        public async Task<ProductDetailsViewModel> GetDetailsAsync(int id)
        {
            var product = await this.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            product.Views++;
            var model = this.Mapper.Map<ProductDetailsViewModel>(product);

            return model;
        }

        public async Task<IEnumerable<ProductListingViewModel>> GetAllAsync(int page = 1, int pageSize = 8)
        {
            var products = await this.Context
                .Products
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();

            return this.ProductsModel(products);
        }

        public async Task<List<CartItemViewModel>> GetAllFromCart(IEnumerable<int> itemIds)
        {
            var products = await this.Context
               .Products
               .Where(pr => itemIds.Contains(pr.Id))
               .ToListAsync();

            var model = this.Mapper
                .Map<IEnumerable<CartItemViewModel>>(products)
                .ToList();

            return model;
        }

        public async Task<IEnumerable<ProductListingViewModel>> FindByCategoryAsync(string categoryName)
        {
            if(categoryName == null)
            {
                return null;
            }

            var products = await this.Context
                .Products
                .OrderByDescending(p => p.Id)
                .Where(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()))
                .ToListAsync();

            return this.ProductsModel(products);
        }

        public async Task<IEnumerable<ProductListingViewModel>> FindByBrandAsync(string brandName)
        {
            if(brandName == null)
            {
                return null;
            }

            var products = await this.Context
                .Products
                .Where(p => p.Brand.Name.ToLower().Contains(brandName.ToLower()))
                .ToListAsync();

            return this.ProductsModel(products);
        }

        public async Task<IEnumerable<ProductListingViewModel>> FindAllBySearchTerm(string searchTerm)
        {
            if (searchTerm == null)
            {
                return null;
            }

            var products = await this.Context
                .Products
                .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToListAsync();

            return this.ProductsModel(products);
        }

        private IEnumerable<ProductListingViewModel> ProductsModel(IEnumerable<Product> products)
            => this.Mapper.Map<IEnumerable<ProductListingViewModel>>(products);
    }
}