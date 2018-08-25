using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChameleonStore.Services.Models;
using ChameleonStore.Services.Interfaces;

namespace ChameleonStore.Services.Implementations
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;

        public ShoppingCartManager()
        {
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string id, int productId)
        {
            var shoppingCart = this.carts.GetOrAdd(id, new ShoppingCart());

            shoppingCart.AddToCart(productId);
        }

        public IEnumerable<CartItem> GetItems(string id)
        {
            var shoppingCart = this.GetShoppingCart(id);

            return new List<CartItem>(shoppingCart.Items);
        }

        public void RemoveFromCart(string id, int productId)
        {
            var shoppingCart = this.carts
                .FirstOrDefault(c => c.Key == id);

            if(shoppingCart.Value != null)
            {
                shoppingCart.Value.RemoveFromCart(productId);
            }
        }

        public void Clear(string id)
            => this.GetShoppingCart(id).Clear();

        private ShoppingCart GetShoppingCart(string id)
            => this.carts.GetOrAdd(id, new ShoppingCart());

        public void Update(string id, int productId, int quantity)
        {
            var shoppingCart = this.carts
                .FirstOrDefault(c => c.Key == id);

            if (shoppingCart.Value != null)
            {
                shoppingCart.Value.Update(productId, quantity);
            }
        }
    }
}
