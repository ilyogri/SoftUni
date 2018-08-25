using AutoMapper;
using ChameleonStore.Common.Orders.ViewModels;
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

namespace ChameleonStore.Services.Implementations
{
    public class OrderService : BaseEFService, IOrderService
    {
        public OrderService(
            ChameleonStoreContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task CreateOrderAsync(string userId, string address, IEnumerable<CartItemViewModel> itemsWithDetails)
        {
            var order = new Order
            {
                Address = address,
                UserId = userId,
                OrderDate = DateTime.UtcNow
            };

            foreach (var item in itemsWithDetails)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity
                };

                order.Items.Add(orderItem);
            }

            await this.Context.Orders.AddAsync(order);
            await this.Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderListingViewModel>> GetUserOrdersAsync(string userId)
        {
            var orders = await this.Context
                .Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                .ToListAsync();

            var model = this.Mapper.Map <IEnumerable<OrderListingViewModel>>(orders);

            return model;
        }
    }
}
