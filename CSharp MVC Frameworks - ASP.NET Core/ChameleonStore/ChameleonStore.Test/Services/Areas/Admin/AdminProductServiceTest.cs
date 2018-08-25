using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Products.BindingModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Admin.Implementations;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Test.Mocks;
using ChameleonStore.Web.Data;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ChameleonStore.Models.Enums;
using Moq;

namespace ChameleonStore.Test.Services.Areas.Admin
{
    public class AdminProductServiceTest
    {
        private readonly ChameleonStoreContext context;
        private readonly IMapper mapper;
        private readonly IAdminProductService adminProductService;
        private readonly IProductService productService;
        private readonly IDropDownListable dropDownService;

        public AdminProductServiceTest()
        {
            this.context = MockDbContext.GetContext();
            this.mapper = MockAutoMapper.GetAutoMapper();
            this.dropDownService = new DropDownListService(this.context, this.mapper);
            this.productService = new ProductService(this.context, this.mapper);
            this.adminProductService = new AdminProductService(this.context, this.mapper, this.productService, this.dropDownService);
        }

        [Fact]
        public async Task EditAsyncShouldReturnFalseWhenProductIdIsNotExisting()
        {
            //Arrange
            var unexistingProductId = 1;
            ProductFormModel productForm = null;

            //Act
            var result = await this.adminProductService.EditAsync(unexistingProductId, productForm);

            //Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public async Task EditAsyncShouldSaveProductChanges()
        {
            //Arrange
            const int id = 1;
            const string nameVaue = "Name";
            const string descriptionValue = "Description";
            const int brandId = 1;
            const int categoryId = 1;
            const string imageUrlValue = "ImageUrl";
            const decimal priceValue = 5;
            const ProductCondition condition = ProductCondition.BrandNew;

            var product = new Product() { Id = id, Category = new Category(), Brand = new Brand() };

            var productFormModel = new ProductFormModel
            {
                Name = nameVaue,
                BrandId = brandId,
                CategoryId = categoryId,
                Description = descriptionValue,
                ImageUrl = imageUrlValue,
                Price = priceValue,
                Condition = condition
            };

            //Act
            this.context.Add(product);
            await this.context.SaveChangesAsync();

            var result = await this.adminProductService.EditAsync(id, productFormModel);

            var productAfterChanges = this.context
                .Products
                .Find(id);

            //Assert
            result
                .Should()
                .BeTrue();

            Assert.Same(product.Name, nameVaue);
            Assert.Equal(product.BrandId, brandId);
            Assert.Equal(product.CategoryId, categoryId);
            Assert.Same(product.Description, descriptionValue);
            Assert.Same(product.ImageURL, imageUrlValue);
            Assert.Equal(product.Price, priceValue);
            Assert.Equal(product.Condition, condition);
        }

        [Fact]
        public async Task DeleteAsyncShouldSuccessfulDeleteEntity()
        {
            //Arange
            const int id = 1;
            var product = new Product() { Id = id, Category = new Category(), Brand = new Brand() };

            //Act
            this.context.Add(product);
            await this.context.SaveChangesAsync();
            var result = await this.adminProductService.DeleteAsync(id);
            var isSuccessfullyDeleted = await this.context
                .Products
                .FindAsync(id) == null;

            //Assert
            result
                .Should()
                .BeTrue();

            isSuccessfullyDeleted
                .Should()
                .BeTrue();
        }
    }
}
