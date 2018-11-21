using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Models;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Controllers
{
    public class CartController : Controller
    {
        private ICart _cart;
        private IInventory _inventory;

        public CartController(ICart cart, IInventory inventory)
        {
            _cart = cart;
            _inventory = inventory;
        }

        public async Task<IActionResult> Index(string username)
        {
            Cart cart = await _cart.GetCart(username);
            List<CartItem> items = _cart.GetAllCartItems(cart);

            dynamic Models = new ExpandoObject();

            Models.CartItems = items;

            IEnumerable<Product> allProducts = await _inventory.GetAllProducts();

            Models.AllProducts = allProducts;


            return View(Models);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string username, int productId)
        {
            if (ModelState.IsValid)
            {
                var cart = await _cart.GetCart(username);
                var product = await _inventory.GetProduct(productId);

                var updateCI = await _cart.GetCartItem(cart.ID, product.ID);

                if (updateCI != null)
                {
                    updateCI.Quantity++;
                    await _cart.UpdateQuantity(updateCI);
                }
                else
                {
                    CartItem newCartItem = new CartItem()
                    {
                        CartID = cart.ID,
                        ProductID = product.ID,
                        Quantity = 1
                    };

                    await _cart.AddToCart(newCartItem);
                }

            }
            return RedirectToAction("Index", "Cart", new { username = username });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int prodID, string username, int quantity)
        {
            Cart userCart = await _cart.GetCart(username);

            CartItem item = await _cart.GetCartItem(userCart.ID, prodID);

            item.Quantity = quantity;

            await _cart.UpdateQuantity(item);

            return RedirectToAction("Index", "Cart", new { username = username });
        }

        //Task<Cart> GetCart(int id);

        //Task<List<CartItem>> GetAllCartItems(Cart cart);

        //Task AddToCart(CartItem ci);

        //Task RemoveFromCart(int cartId, int productId);
    }
}
