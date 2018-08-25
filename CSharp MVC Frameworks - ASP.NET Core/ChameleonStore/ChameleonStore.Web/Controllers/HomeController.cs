using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChameleonStore.Web.Models;
using ChameleonStore.Web.Data;
using AutoMapper;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Common.Home.ViewModels;
using ChameleonStore.Common.Home.BindingModels;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Common.Paging;

namespace ChameleonStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService products;

        public HomeController(IProductService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index(int page = 1)
            => View(new IndexViewModel
            {
                Products = await this.products.GetAllAsync(page, WebConstants.PageSize),
                Paging = new PagingViewModel
                {
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(this.products.Total() / (double)WebConstants.PageSize)
                }
            });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText
            };

            if (model.SearchByBrands)
            {
                viewModel.Products = await this.products.FindByBrandAsync(model.SearchText);
                viewModel.FilterName = WebConstants.BrandFilterName;
            }
            else if (model.SearchByCategories)
            {
                viewModel.Products = await this.products.FindByCategoryAsync(model.SearchText);
                viewModel.FilterName = WebConstants.CategoryFilterName;
            }
            else
            {
                viewModel.Products = await this.products.FindAllBySearchTerm(model.SearchText);
            }

            return View(viewModel);
        }
    }
}
