using ChameleonStore.Common.Products.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonStore.Common.Home.ViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<ProductListingViewModel> Products { get; set; }

        public string SearchText { get; set; }

        public string FilterName { get; set; }
    }
}
