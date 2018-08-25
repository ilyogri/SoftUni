using ChameleonStore.Models;

namespace ChameleonStore.Common.Products.ViewModels
{
    public class ProductListingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Views { get; set; }

        public decimal Discount { get; set; }
    }
}