using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ChameleonStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ChameleonStore.Services;
using ChameleonStore.Web.Infrastructure.Extensions;
using ChameleonStore.Services.Interfaces;

namespace ChameleonStore.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly ILogger<LogoutModel> logger;
        private readonly IShoppingCartManager shoppingCartManager;

        public LogoutModel(
            SignInManager<User> signInManager, 
            ILogger<LogoutModel> logger,
            IShoppingCartManager shoppingCartManager)
        {
            this.signInManager = signInManager;
            this.logger = logger;
            this.shoppingCartManager = shoppingCartManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            shoppingCartManager.Clear(shoppingCartId);
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}