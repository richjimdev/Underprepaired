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

        public async Task<Cart> GetCart(string username)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<CartItem> GetCartItem(int cartId, int productId)
        {
            return await _context.CartItems.FindAsync(productId, cartId);
        }
        
        public async Task<List<CartItem>> GetAllCartItems(Cart cart)
        {
            return await _context.CartItems.Where(x => x.CartID == cart.ID).ToListAsync();
        }

        public async Task AddToCart(CartItem ci)
        {
            _context.CartItems.Add(ci);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(int cartId, int productId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartId, productId);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateQuantity(CartItem ci)
        {
            _context.CartItems.Update(ci);
            await _context.SaveChangesAsync();
        }
    }
}
