using ChameleonStore.Services.Models;
using System.Collections.Generic;

namespace ChameleonStore.Services.Interfaces
{
    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        void RemoveFromCart(string id, int productId);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string shoppingCartId);

        void Update(string id, int productId, int quantity);
    }
}