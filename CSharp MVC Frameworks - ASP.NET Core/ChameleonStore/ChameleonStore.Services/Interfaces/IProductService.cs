using ChameleonStore.Common.Home.ViewModels;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Common.ShoppingCart.ViewModels;
using ChameleonStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Interfaces
{
    public interface IProductService
    {
        int Total();

        Task<Product> GetByIdAsync(int id);

        Task<ProductDetailsViewModel> GetDetailsAsync(int id);

        Task<IEnumerable<ProductListingViewModel>> GetAllAsync(int page = 1, int pageSize = 8);

        Task<List<CartItemViewModel>> GetAllFromCart(IEnumerable<int> itemIds);

        Task<IEnumerable<ProductListingViewModel>> FindByCategoryAsync(string categoryName);

        Task<IEnumerable<ProductListingViewModel>> FindByBrandAsync(string brandName);

        Task<IEnumerable<ProductListingViewModel>> FindAllBySearchTerm(string searchTerm);
    }
}
