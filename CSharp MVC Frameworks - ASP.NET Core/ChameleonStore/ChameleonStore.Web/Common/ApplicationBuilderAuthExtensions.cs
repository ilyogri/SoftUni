using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ChameleonStore.Models;
using ChameleonStore.Web.Data;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using ChameleonStore.Common.SeedDtoModels;
using System;
using System.Collections.Generic;

namespace ChameleonStore.Web.Common
{
    public static class ApplicationBuilderAuthExtensions
    {
        private const string DefaultAdminPassword = "admin123";
        private const string DatasetsPath = @"wwwroot\dbsets\{0}.json";
        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(WebConstants.AdministratorRole),
            new IdentityRole(WebConstants.CustomerRole)
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };

                    await userManager.CreateAsync(user, DefaultAdminPassword);
                    await userManager.AddToRoleAsync(user, roles[0].Name);
                }

                var context = scope.ServiceProvider.GetService<ChameleonStoreContext>();

                if (!context.Categories.Any())
                {
                    var jsonProducts = File.ReadAllText(string.Format(DatasetsPath, "categories"));
                    var categoryDtos = JsonConvert.DeserializeObject<CategoryDto[]>(jsonProducts);

                    SeedCategories(context, categoryDtos);
                }

                if (!context.Brands.Any())
                {
                    var jsonProducts = File.ReadAllText(string.Format(DatasetsPath, "brands"));
                    var brandDtos = JsonConvert.DeserializeObject<BrandDto[]>(jsonProducts);

                    SeedBrands(context, brandDtos);
                }

                if (!context.Products.Any())
                {
                    var jsonProducts = File.ReadAllText(string.Format(DatasetsPath, "products"));
                    var productDtos = JsonConvert.DeserializeObject<ProductDto[]>(jsonProducts);

                    SeedProducts(context, productDtos);
                }
            }
        }

        private static void SeedCategories(ChameleonStoreContext context, CategoryDto[] categoryDtos)
        {
            var categoriesToCreate = categoryDtos
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToArray();

            context.Categories.AddRange(categoriesToCreate);
             context.SaveChanges();
        }

        private static void SeedBrands(ChameleonStoreContext context, BrandDto[] brandDtos)
        {
            var brandsToCreate = brandDtos
                 .Select(c => new Brand
                 {
                     Name = c.Name
                 })
                 .ToArray();

            context.Brands.AddRange(brandsToCreate);
            context.SaveChanges();
        }

        private static void SeedProducts(ChameleonStoreContext context, ProductDto[] productDtos)
        {
            var productsToCreate = new List<Product>();
            foreach (var productDto in productDtos)
            {
                var category = context.Categories.SingleOrDefault(x => x.Name == productDto.CategoryName);
                var brand = context.Brands.SingleOrDefault(x => x.Name == productDto.BrandName);

                if (category != null)
                {
                    var product = new Product
                    {
                        Name = productDto.Name,
                        ImageURL = productDto.ImageURL,
                        Price = productDto.Price,
                        Discount = productDto.Discount,
                        Condition = productDto.Condition,
                        Description = productDto.Description,
                        BrandId = brand.Id,
                        CategoryId = category.Id,
                        Views = productDto.Views
                    };

                    productsToCreate.Add(product);
                }
            }

            context.Products.AddRange(productsToCreate);
            context.SaveChanges();
        }
    }
}
