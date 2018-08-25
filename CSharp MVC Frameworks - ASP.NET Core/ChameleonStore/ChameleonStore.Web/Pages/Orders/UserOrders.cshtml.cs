using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChameleonStore.Common.Orders.ViewModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChameleonStore.Web.Pages.Orders
{
    public class UserOrders : PageModel
    {
        private readonly SignInManager<User> signManager;
        private readonly IOrderService orders;

        public UserOrders(
           SignInManager<User> signManager,
           IOrderService orders)
        {
            this.signManager = signManager;
            this.orders = orders;
        }

        [BindProperty]
        public IEnumerable<OrderListingViewModel> Input { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            this.Input = await orders
                .GetUserOrdersAsync(id);

            return Page();
        }
    }
}