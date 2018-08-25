using ChameleonStore.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChameleonStore.Common.Areas.Admin.Products.BindingModels
{
    public class ProductFormModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; }

        [Required]
        public ProductCondition Condition { get; set; }

        [Display(Name = "Brand")]
        [Required]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
