using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models.Interfaces
{
    public interface ICart
    {
        Task<Cart> GetCart(string username);

        List<CartItem> GetAllCartItems(Cart cart);

        Task<CartItem> GetCartItem(int cartId, int productId);

        Task AddToCart(CartItem ci);

        Task RemoveFromCart(int cartId, int productId);

        Task UpdateQuantity(CartItem ci);

        Task RemoveAllCartItems(int cartId, List<CartItem> items);

        Task CreateOrder(Order order);
    }
}
