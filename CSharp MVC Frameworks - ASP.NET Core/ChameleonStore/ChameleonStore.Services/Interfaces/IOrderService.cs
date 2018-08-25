using ChameleonStore.Common.Orders.ViewModels;
using ChameleonStore.Common.ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, string address, IEnumerable<CartItemViewModel> itemsWithDetails);

        Task<IEnumerable<OrderListingViewModel>> GetUserOrdersAsync(string userId);
    }
}
