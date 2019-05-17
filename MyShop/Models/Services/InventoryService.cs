using Microsoft.EntityFrameworkCore;
using MyShop.data;
using MyShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models.Services
{
    public class InventoryService : IInventoryManager
    {
        private MyShopDbContext _context;

        public InventoryService(MyShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetALLProducts()
        {
            return await _context.Product.ToListAsync();
        }

        /// <summary>
        /// will get a specific product
        /// </summary>
        /// <param name="id">product identification</param>
        /// <returns>returns a specific product</returns>
        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var product =  await _context.Product.FirstOrDefaultAsync(x => x.ID == id);
               
                                           
                return product;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
