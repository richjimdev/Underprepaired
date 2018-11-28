using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Data;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Models.Components
{
    public class CartPreview : ViewComponent
    {
        private ICart _cart;
        private IInventory _inventory;

        public CartPreview(ICart cart, IInventory inventory)
        {
            _cart = cart;
            _inventory = inventory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {

            Cart cart = await _cart.GetCart(username);
            List<CartItem> items = _cart.GetAllCartItems(cart);

            dynamic Models = new ExpandoObject();

            Models.CartItems = items;

            IEnumerable<Product> allProducts = await _inventory.GetAllProducts();

            Models.AllProducts = allProducts;

            return View(Models);
        }
    }
}
