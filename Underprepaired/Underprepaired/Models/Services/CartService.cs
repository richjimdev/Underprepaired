using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Data;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Models.Services
{
    public class CartService : ICart
    {
        private UnderprepairedDbContext _context;

        public CartService(UnderprepairedDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Fetches the cart for user
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <returns>The user's cart</returns>
        public async Task<Cart> GetCart(string username)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Username == username);
        }

        /// <summary>
        /// Fetch item from cart
        /// </summary>
        /// <param name="cartId">Cart to grab from</param>
        /// <param name="productId">Product to grab</param>
        /// <returns>The product</returns>
        public async Task<CartItem> GetCartItem(int cartId, int productId)
        {
            return await _context.CartItems.FindAsync(productId, cartId);
        }
        
        /// <summary>
        /// Grabs all items in cart
        /// </summary>
        /// <param name="cart">Cart to grab from</param>
        /// <returns>All items in cart</returns>
        public List<CartItem> GetAllCartItems(Cart cart)
        {
            return _context.CartItems.Where(x => x.CartID == cart.ID).ToList();
        }

        /// <summary>
        /// Adds item to cart
        /// </summary>
        /// <param name="ci">Cart item to add</param>
        public async Task AddToCart(CartItem ci)
        {
            _context.CartItems.Add(ci);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes item from cart
        /// </summary>
        /// <param name="cartId">Cart to remove from</param>
        /// <param name="productId">Item to remove</param>
        public async Task RemoveFromCart(int cartId, int productId)
        {
            var cartItem = await _context.CartItems.FindAsync(productId, cartId);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates quantity of item in cart
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        public async Task UpdateQuantity(CartItem ci)
        {
            _context.CartItems.Update(ci);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all cart items
        /// </summary>
        /// <param name="cartId">The cart id</param>
        /// <param name="items">The items in that cart</param>
        /// <returns></returns>
        public async Task RemoveAllCartItems(int cartId, List<CartItem> items)
        {
            foreach(CartItem item in items)
            {
                var cartItem = await _context.CartItems.FindAsync(item.ProductID, cartId);
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="order">The order to be added to table</param>
        /// <returns></returns>
        public async Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
