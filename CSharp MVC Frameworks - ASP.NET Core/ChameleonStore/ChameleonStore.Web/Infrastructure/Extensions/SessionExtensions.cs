using Microsoft.AspNetCore.Http;
using System;

namespace ChameleonStore.Web.Infrastructure.Extensions
{
    public static class SessionExtensions
    {
        private const string ShoppingCartId = "Shopping_Cart_Id";

        public static string GetShoppingCartId(this ISession session)
        {
            var shoppingCartId = session.GetString(ShoppingCartId);

            if (shoppingCartId == null)
            {
                shoppingCartId = Guid.NewGuid().ToString();
                session.SetString(ShoppingCartId, shoppingCartId);
            }

            return shoppingCartId;
        }
    }
}
