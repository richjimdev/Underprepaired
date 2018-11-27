using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Underprepaired.Models;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Controllers
{
    public class CheckoutController : Controller
    {
        private ICart _cart;
        private IInventory _inventory;

        public CheckoutController(ICart cart, IInventory inventory)
        {
            _cart = cart;
            _inventory = inventory;
        }
        public async Task<IActionResult> Receipt(string username)
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