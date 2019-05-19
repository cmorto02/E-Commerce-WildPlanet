using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Interfaces
{
    public interface IInventoryManager
    {
        /// <summary>
        /// gets all products to list on the shop page
        /// </summary>
        /// <returns>List of all products</returns>
        Task<IEnumerable<Product>> GetALLProducts();

        Task<Product> GetProduct(int id);

        Task NewProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);

        Task<List<Product>> GetOrderedProducts();
    }
}
