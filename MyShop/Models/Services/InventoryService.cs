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

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetALLProducts()
        {
            throw new NotImplementedException();
        }

        public void GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
