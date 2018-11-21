using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Underprepaired.Data;
using Underprepaired.Models;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IInventory _context;
        private ICart _cart;

        public ProductsController(IInventory context, ICart cart)
        {
            _context = context;
            _cart = cart;
        }

        // GET: Products
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllProducts());
        }

        [AllowAnonymous]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allProducts = await _context.GetAllProducts();
            Product product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price,ImageURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateProduct(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price,ImageURL")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.GetProduct(id) != null;
        }

        //private async bool CartItemExists(int cartId, int productId)
        //{
        //    return await _cart.GetCartItem(cartId, productId) != null;
        //}

        [HttpPost]
        public async Task<IActionResult> AddToCart(string username, int productId)
        {
            if (ModelState.IsValid)
            {
                var cart = await _cart.GetCart(username);
                var product = await _context.GetProduct(productId);
                
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

            return RedirectToAction("Index");
        }
    }
}
