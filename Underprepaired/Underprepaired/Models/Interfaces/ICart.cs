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

        void AddToCart(CartItem ci);

        void RemoveFromCart(int cartId, int productId);

        void UpdateQuantity(CartItem ci);
    }
}
