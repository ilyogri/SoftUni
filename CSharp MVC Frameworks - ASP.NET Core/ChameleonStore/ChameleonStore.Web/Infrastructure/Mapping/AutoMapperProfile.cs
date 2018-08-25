using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Products.ViewModels;
using ChameleonStore.Common.Areas.Admin.Users.ViewModels;
using ChameleonStore.Common.Orders.ViewModels;
using ChameleonStore.Common.Products.ViewModels;
using ChameleonStore.Common.ShoppingCart.ViewModels;
using ChameleonStore.Models;
using ChameleonStore.Web.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChameleonStore.Web.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(pd => pd.Brand,
                            p => p.MapFrom(src => src.Brand.Name))
                .ForMember(pd => pd.Category,
                            p => p.MapFrom(src => src.Category.Name));
            this.CreateMap<Product, AdminProductListingViewModel>()
                .ForMember(pd => pd.Brand, p => p.MapFrom(src => src.Brand.Name))
                .ForMember(pd => pd.Category, p => p.MapFrom(src => src.Category.Name));
            this.CreateMap<Product, ProductListingViewModel>();
            this.CreateMap<Product, CartItemViewModel>()
                .ForMember(pd => pd.ProductId,
                            p => p.MapFrom(src => src.Id));
            this.CreateMap<Order, OrderListingViewModel>()
                .ForMember(olm => olm.Products,
                            p => p.MapFrom(src => src.Items.Sum(i => i.Quantity)));
            this.CreateMap<User, UserListingModel>()
                .ForMember(ulm => ulm.OrdersMade,
                            u => u.MapFrom(src => src.Orders.Count));
        }
    }
}