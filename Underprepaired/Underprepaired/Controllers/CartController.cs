using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CartController : Controller
    {
        private ICart _cart;
        private IInventory _inventory;

        public CartController(ICart cart, IInventory inventory)
        {
            _cart = cart;
            _inventory = inventory;
        }

        /// <summary>
        /// Displays Cart items
        /// </summary>
        /// <param name="username">User username</param>
        /// <returns>A razor view</returns>
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

        /// <summary>
        /// Adds item to the cart
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="productId">Product to add</param>
        /// <param name="quantity">Quantity of product to add</param>
        /// <returns>Razor View</returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(string username, int productId, int quantity)
        {
            if (ModelState.IsValid)
            {
                var cart = await _cart.GetCart(username);
                var product = await _inventory.GetProduct(productId);

                var updateCI = await _cart.GetCartItem(cart.ID, product.ID);

                if (updateCI != null)
                {
                    updateCI.Quantity += quantity;
                    await _cart.UpdateQuantity(updateCI);
                }
                else
                {
                    CartItem newCartItem = new CartItem()
                    {
                        CartID = cart.ID,
                        ProductID = product.ID,
                        Quantity = quantity
                    };

                    await _cart.AddToCart(newCartItem);
                }

            }
            return RedirectToAction("Index", "Cart", new { username = username });
        }

        /// <summary>
        /// Updates Quantity of item in cart
        /// </summary>
        /// <param name="prodID">Product to update</param>
        /// <param name="username">User's username</param>
        /// <param name="quantity">New quantity</param>
        /// <returns>Razor View</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int prodID, string username, int quantity)
        {
            Cart userCart = await _cart.GetCart(username);

            if (quantity <= 0)
            {
                await DeleteItem(username, userCart.ID, prodID);
            }
            else
            {
                CartItem item = await _cart.GetCartItem(userCart.ID, prodID);

                item.Quantity = quantity;

                await _cart.UpdateQuantity(item);
            }

            return RedirectToAction("Index", "Cart", new { username = username });
        }

        /// <summary>
        /// Removes item from cart
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="cartID">Cart of user</param>
        /// <param name="prodID">Product to remove</param>
        /// <returns>Razor View</returns>
        public async Task<IActionResult> DeleteItem(string username, int cartID, int prodID)
        {
            await _cart.RemoveFromCart(cartID, prodID);

            return RedirectToAction("Index", "Cart", new { username = username });
        }
    }
}
