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
        Task<List<Product>> GetALLProducts();

    }
}
