using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underprepaired.Data;
using Underprepaired.Models.Interfaces;

namespace Underprepaired.Models.Services
{
    public class InventoryService : IInventory
    {
        private UnderprepairedDbContext _context;

        public InventoryService(UnderprepairedDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Gets the product by id
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public async Task<List<Product>> GetSingleProductList(int? id)
        {
            var result = await _context.Products.FindAsync(id);
            List<Product> list = new List<Product>();
            list.Add(result);
            return list;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns></returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task DeleteProduct(int id)
        {
            Product product = await GetProduct(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
