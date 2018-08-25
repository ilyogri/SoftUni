using ChameleonStore.Services.Admin.Implementations;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChameleonStore.Web.Common
{
    public static class ServicesConfiguration
    {
        public static void RegisterAll(IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, SendGridEmailSender>();
            services.AddSingleton<IShoppingCartManager, ShoppingCartManager>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDropDownListable, DropDownListService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}