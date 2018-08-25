using AutoMapper;
using ChameleonStore.Common.Home.BindingModels;
using ChameleonStore.Common.Home.ViewModels;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Implementations;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Test.Mocks;
using ChameleonStore.Web.Controllers;
using ChameleonStore.Web.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChameleonStore.Test.Web.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public async Task IndexShouldReturnValidIndexViewModel()
        {
            //Arange
            const string searchText = null;
            var productService = new Mock<IProductService>();
            productService
                .Setup(c => c.GetAllAsync(1, 25))
                .ReturnsAsync(new List<ProductListingViewModel>
                {
                     new ProductListingViewModel
                     {
                         Id = 5
                     }
                });

            var controller = new HomeController(productService.Object);

            //Act
            var result = await controller.Index(1);

            //Assert
            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<IndexViewModel>();

            var homeViewModel = result.As<ViewResult>().Model.As<IndexViewModel>();

            homeViewModel.Products.Should().Match(c => c.As<List<ProductListingViewModel>>().Count == 1);
            homeViewModel.Products.First().Should().Match(c => c.As<ProductListingViewModel>().Id == 5);
            homeViewModel.SearchText.Should().Be(searchText);
        }

        [Fact]
        public async Task SearchShouldReturnNoResultsWhenUnmatchingSearchFilterIsGiven()
        {
            // Arrange
            const string searchText = null;
            var productService = new Mock<IProductService>();
            productService
                .Setup(c => c.FindByBrandAsync(null))
                .ReturnsAsync(new List<ProductListingViewModel>());

            var controller = new HomeController(productService.Object);

            // Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchByCategories = true,
                SearchByBrands = true,
                SearchText = searchText
            });

            // Assert
            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Products.Should().BeEmpty();
            searchViewModel.SearchText.Should().BeNull();
        }

        [Fact]
        public async Task SearchShouldReturnViewWithValidModelWhenProductsAreFiltered()
        {
            // Arrange
            const string brandFilter = "LG";
            const int id = 5;

            var productService = new Mock<IProductService>();
            productService
                .Setup(c => c.FindByBrandAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<ProductListingViewModel>
                {
                    new ProductListingViewModel() { Id = id },
                    new ProductListingViewModel()
                });

            var controller = new HomeController(productService.Object);

            // Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchText = brandFilter,
                SearchByBrands = true,
                SearchByCategories = false
            });

            // Assert
            result.Should().BeOfType<ViewResult>();

            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Products.Should().Match(c => c.As<List<ProductListingViewModel>>().Count == 2);
            searchViewModel.Products.First().Should().Match(c => c.As<ProductListingViewModel>().Id == 5);
            searchViewModel.SearchText.Should().Be(brandFilter);
        }
    }
}
