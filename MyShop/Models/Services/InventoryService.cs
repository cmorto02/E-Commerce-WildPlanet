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

        public async Task DeleteProduct(int id)
        {
            Product product = _context.Product.FirstOrDefault(i => i.ID == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetALLProducts()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<List<Product>> GetOrderedProducts()
        {
            var prods = await GetALLProducts();
            var orderedProds = prods.OrderByDescending(i => i.ID).ToList();
            return orderedProds;
        }

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

        public async Task NewProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
