using ChameleonStore.Common.Paging;
using ChameleonStore.Common.Products.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChameleonStore.Common.Home.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.SearchByBrands = false;
            this.SearchByCategories = false;
        }

        public IEnumerable<ProductListingViewModel> Products { get; set; }

        public string SearchText { get; set; }

        [Display(Name = "Search By Categories")]
        public bool SearchByCategories { get; set; }

        [Display(Name = "Search By Brands")]
        public bool SearchByBrands { get; set; }

        public PagingViewModel Paging { get; set; }
    }
}
