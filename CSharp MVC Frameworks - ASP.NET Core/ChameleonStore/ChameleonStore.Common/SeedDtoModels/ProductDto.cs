using ChameleonStore.Models.Enums;

namespace ChameleonStore.Common.SeedDtoModels
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        
        public ProductCondition Condition { get; set; }

        public string ImageURL { get; set; }

        public decimal Discount { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public int Views { get; set; }
    }
}
