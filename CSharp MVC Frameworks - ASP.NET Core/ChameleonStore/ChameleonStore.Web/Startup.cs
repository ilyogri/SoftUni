using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChameleonStore.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChameleonStore.Models;
using ChameleonStore.Web.Common;
using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using ChameleonStore.Web.Areas.Identity.Services;
using ChameleonStore.Services;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Admin.Implementations;
using ChameleonStore.Services.Interfaces;

namespace ChameleonStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ChameleonStoreContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ChameleonStore")));

            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ChameleonStoreContext>();

            services
                .AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = this.Configuration.GetSection("ExternalAuthentication:Facebook:AppId").Value;
                    options.AppSecret = this.Configuration.GetSection("ExternalAuthentication:Facebook:AppSecret").Value;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = this.Configuration.GetSection("ExternalAuthentication:Google:ClientId").Value;
                    options.ClientSecret = this.Configuration.GetSection("ExternalAuthentication:Google:ClientSecret").Value;
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 5,
                    RequiredUniqueChars = 2,
                    RequireLowercase = true,
                    RequireDigit = true,
                    RequireUppercase = true,
                    RequireNonAlphanumeric = true
                };

                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAutoMapper();
            services.AddSession();

            ServicesConfiguration.RegisterAll(services);

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
