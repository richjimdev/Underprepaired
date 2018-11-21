using Microsoft.AspNetCore.Mvc;
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
        private ICart _context;

        public CartPreview(ICart context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var cart = await _context.GetCart(username);

            var ci = await _context.GetAllCartItems(cart);

            return View(ci);
        }
    }
}
