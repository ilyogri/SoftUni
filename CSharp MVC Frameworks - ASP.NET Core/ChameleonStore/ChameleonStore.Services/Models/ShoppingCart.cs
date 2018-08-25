using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChameleonStore.Services.Models
{
    public class ShoppingCart
    {
        private readonly IList<CartItem> items;

        public ShoppingCart()
        {
            this.items = new List<CartItem>();
        }

        public IEnumerable<CartItem> Items => new List<CartItem>(this.items);

        public void AddToCart(int productId)
        {
            var cartItem = this.items.FirstOrDefault(p => p.ProductId == productId);

            if(cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                };

                this.items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = this.items
                .FirstOrDefault(p => p.ProductId == productId);

            if(cartItem != null)
            {
                this.items.Remove(cartItem);
            }
        }

        public void Clear()
            => this.items.Clear();

        public void Update(int productId, int quantity)
        {
            var cartItem = this.items
               .FirstOrDefault(p => p.ProductId == productId);

            if(cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
        }
    }
}
