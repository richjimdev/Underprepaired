using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models.Interfaces
{
    interface ICart
    {
        Task<CartItem> GetAllCartItems(string username);

        Task AddToCart(Product product);

        Task RemoveFromCart(int cartId, int productId);

        Task UpdateQuantity(int cartId, int productId, Product product);
    }
}
