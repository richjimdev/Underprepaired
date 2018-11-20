using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models.Interfaces
{
    interface ICart
    {
        Task<Cart> GetCart(int id);

        Task<List<CartItem>> GetAllCartItems(Cart cart);

        Task AddToCart(CartItem ci);

        Task RemoveFromCart(int cartId, int productId);

        Task UpdateQuantity(CartItem ci);
    }
}
