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

        public ProductsController(IInventory context)
        {
            _context = context;
        }

        // GET: Products        
        /// <summary>
        /// Renders the all products shopping page
        /// </summary>
        /// <returns>returns view with product information</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllProducts());
        }

        // GET: Products/Details/5
        /// <summary>
        /// Renders a product details page
        /// </summary>
        /// <param name="id">The product id</param>
        /// <returns>redirects to the products details view</returns>
        [AllowAnonymous]
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
        /// <summary>
        /// Renders the create a product view
        /// </summary>
        /// <returns>returns create view</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create        
        /// <summary>
        /// Creates a new products
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns>product details view</returns>
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
        /// <summary>
        /// Renders product edit page
        /// </summary>
        /// <param name="id">The id for the product</param>
        /// <returns>returns product details page</returns>
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
        /// <summary>
        /// Edits the product
        /// </summary>
        /// <param name="id">The product id</param>
        /// <param name="product">The product to be edited</param>
        /// <returns></returns>
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
        /// <summary>
        /// Renders delete confirmation page
        /// </summary>
        /// <param name="id">The id for the product/param>
        /// <returns>renders delete confirmation view</returns>
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
        /// <summary>
        /// Deletes the product
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns></returns>
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
    }
}
