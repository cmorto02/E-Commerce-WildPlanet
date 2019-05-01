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

        public void GetByID(int id)
        {
            throw new NotImplementedException();
        }

  
    }
}
