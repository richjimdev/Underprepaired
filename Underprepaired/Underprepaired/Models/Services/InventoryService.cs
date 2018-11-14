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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task CreateHotel(Product product)
        {

        }

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
