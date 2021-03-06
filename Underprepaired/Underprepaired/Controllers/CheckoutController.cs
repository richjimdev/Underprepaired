﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Underprepaired.Models;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Controllers
{
    public class CheckoutController : Controller
    {
        private ICart _cart;
        private IInventory _inventory;
        private IEmailSender _email;


        public CheckoutController(ICart cart, IInventory inventory, IEmailSender email)
        {
            _cart = cart;
            _inventory = inventory;
            _email = email;
        }

        /// <summary>
        /// Compiles a receipt of purchase
        /// </summary>
        /// <param name="username">User's username</param>
        /// <returns>Razor view</returns>
        public async Task<IActionResult> Receipt(string username)
        {
            // Get object for view
            Cart cart = await _cart.GetCart(username);
            List<CartItem> items = _cart.GetAllCartItems(cart);

            dynamic Models = new ExpandoObject();

            Models.CartItems = items;

            IEnumerable<Product> allProducts = await _inventory.GetAllProducts();

            Models.AllProducts = allProducts;


            // Receipt email
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("</h2>Your Order:</h2>");

            decimal total = 0;

            foreach (var item in items)
            {
                decimal subTotal = item.Product.Price * item.Quantity;
                sb.AppendLine($"<h4>{item.Product.Name}</h4>");
                sb.AppendLine($"<p>Price: ${item.Product.Price}</p>");
                sb.AppendLine($"<h5>Qty: {item.Quantity}</h5>");
                sb.AppendLine($"<h4>Total: ${subTotal}</h4>");
                total += subTotal;
            }
            sb.AppendLine($"<h4>Grand Total: ${total}</h4>");

            await _email.SendEmailAsync(username, "Order Complete", sb.ToString());

            // Create order
            await _cart.RemoveAllCartItems(cart.ID, items);

            Order order = new Order();
            order.Username = username;
            order.Date = DateTime.Now;
            order.Total = total;

            await _cart.CreateOrder(order);

            // return view with expando object
            return View(Models);
        }
    }
}