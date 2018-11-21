using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Data;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Models.Components
{
    public class CartPreview : ViewComponent
    {
        private UnderprepairedDbContext _context;

        public CartPreview(UnderprepairedDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.Username == username);

            List<CartItem> ci = await _context.CartItems.Where(y => y.CartID == cart.ID).ToListAsync();

            return View(ci);
        }
    }
}
