using AutoMapper;
using ChameleonStore.Models;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Test.Mocks;
using ChameleonStore.Web.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChameleonStore.Test.Services
{
    public class ProductServiceTest
    {
        private readonly ChameleonStoreContext context;
        private readonly IMapper mapper;
        private readonly ProductService products;

        public ProductServiceTest()
        {
            this.context = MockDbContext.GetContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
            this.products = new ProductService(this.context, this.mapper);
        }

        [Fact]
        public async Task FindByCategoryAsyncShouldReturnCorrectResultsWithFilter()
        {
            //Arrange
            var firstCategory = new Category { Id = 1, Name = "Laptops" };
            var secondCategory = new Category { Id = 2, Name = "Mouses" };
            var firstProduct = new Product { Id = 1, Name = "Acer Aspire", CategoryId = 1 };
            var secondProduct = new Product { Id = 2, Name = "LG Mouse", CategoryId = 2 };
            var thirdProduct = new Product { Id = 3, Name = "ASUS Chromebook C202SA", CategoryId = 1 };

            this.context.AddRange(firstCategory, secondCategory, firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            var result = await this.products.FindByCategoryAsync("Laptops");

            //Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == 3)
                .And
                .Match(r => r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task FindByBrandAsyncShouldReturnCorrectResultsWithFilter()
        {
            //Arrange
            var firstBrand = new Brand { Id = 1, Name = "LG" };
            var secondBrand = new Brand { Id = 2, Name = "ASUS" };
            var firstProduct = new Product { Id = 1, Name = "ASUS Aspire", BrandId = 2 };
            var secondProduct = new Product { Id = 2, Name = "LG Mouse", BrandId = 1 };
            var thirdProduct = new Product { Id = 3, Name = "ASUS Chromebook C202SA", BrandId = 2 };

            this.context.AddRange(firstBrand, secondBrand, firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            var result = await this.products.FindByBrandAsync("lg");

            //Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == 2)
                .And
                .HaveCount(1);
        }
    }
}
