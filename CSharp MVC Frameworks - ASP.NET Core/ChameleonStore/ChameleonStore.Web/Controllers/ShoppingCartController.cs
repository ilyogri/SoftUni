using AutoMapper;
using ChameleonStore.Models;
using ChameleonStore.Services;
using ChameleonStore.Services.Models;
using ChameleonStore.Web.Data;
using ChameleonStore.Web.Infrastructure.Extensions;
using ChameleonStore.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ChameleonStore.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using ChameleonStore.Common.ShoppingCart.ViewModels;

namespace ChameleonStore.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly UserManager<User> userManager;
        private readonly IOrderService orders;
        private readonly IProductService products;

        public ShoppingCartController(
            IShoppingCartManager shoppingCartManager,
            UserManager<User> userManager,
            IOrderService orders,
            IProductService products)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.userManager = userManager;
            this.orders = orders;
            this.products = products;
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.RemoveFromCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        [HttpPost]
        public IActionResult Update(int id, int quantity)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.Update(shoppingCartId, id, quantity);

            return RedirectToAction(nameof(Items));
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsWithDetails = await this.GetCartItems(items);

            return View(itemsWithDetails);
        }

        [HttpGet]
        [Authorize]
        public IActionResult FinishOrder()
            => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FinishOrderConfirm(OrderFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            if (items.Count() == 0)
            {
                return BadRequest();
            }

            var itemsWithDetails = await this.GetCartItems(items);
            var userId = this.userManager.GetUserId(User);

            await this.orders.CreateOrderAsync(userId, model.Address, itemsWithDetails);

            shoppingCartManager.Clear(shoppingCartId);

            TempData.AddSuccessMessage($"Your order has been successfully listed!");

            return RedirectToPage("/Orders/UserOrders", new { id = userId });
        }

        private async Task<IEnumerable<CartItemViewModel>> GetCartItems(IEnumerable<CartItem> items)
        {
            var itemIds = items.Select(i => i.ProductId);

            var itemsWithDetails = await this.products
                 .GetAllFromCart(itemIds);

            var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);

            itemsWithDetails
                .ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return itemsWithDetails;
        }
    }
}