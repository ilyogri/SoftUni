using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChameleonStore.Common.Home.BindingModels
{
    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Categories")]
        public bool SearchByCategories { get; set; }

        [Display(Name = "Search In Brands")]
        public bool SearchByBrands { get; set; }
    }
}
