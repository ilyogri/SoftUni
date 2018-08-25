namespace ChameleonStore.Common.ShoppingCart.ViewModels
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
