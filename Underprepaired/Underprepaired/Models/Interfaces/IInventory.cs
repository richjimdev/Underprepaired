using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Underprepaired.Models.Interfaces
{
    public interface IInventory
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(int? id);

        Task<List<Product>> GetSingleProductList(int? id);

        Task CreateProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
