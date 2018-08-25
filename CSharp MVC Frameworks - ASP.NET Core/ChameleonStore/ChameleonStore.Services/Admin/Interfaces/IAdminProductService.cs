using ChameleonStore.Common.Areas.Admin.Products.BindingModels;
using ChameleonStore.Common.Areas.Admin.Products.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Admin.Interfaces
{
    public interface IAdminProductService
    {
        Task<IEnumerable<AdminProductListingViewModel>> GetAllAsync();

        Task<int> CreateAndGetIdAsync(ProductFormModel model);

        Task<ProductFormModel> GetEditModelAsync(int id);

        Task<bool> EditAsync(int id, ProductFormModel model);

        Task<bool> DeleteAsync(int id);
    }
}
