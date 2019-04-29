using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Interfaces
{
    public interface IInventoryManager
    {
        Task CreateProduct(Product product);

        Task<IEnumerable<Product>> GetALLProducts();

        Task<IActionResult> GetProduct(int id);

        Task UpdateProduct(int id, Product product);

        Task<Product> DeleteProduct(int id);

        Task<IActionResult> DeleteProductFR(int id);
    }
}
